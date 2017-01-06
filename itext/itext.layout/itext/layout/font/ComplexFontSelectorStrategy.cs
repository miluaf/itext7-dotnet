using System;
using System.Collections.Generic;
using iText.IO.Font.Otf;
using iText.IO.Util;
using iText.Kernel.Font;

namespace iText.Layout.Font {
    public class ComplexFontSelectorStrategy : FontSelectorStrategy {
        internal PdfFont font;

        internal FontSelector selector;

        public ComplexFontSelectorStrategy(String text, FontSelector selector)
            : base(text) {
            this.font = null;
            this.selector = selector;
        }

        public override PdfFont GetFont() {
            return font;
        }

        public override IList<Glyph> NextGlyphs() {
            IList<Glyph> glyphs = new List<Glyph>();
            font = null;
            int nextUnignorable = NextUnignorableIndex();
            foreach (PdfFont f in selector.GetFonts()) {
                if (f.ContainsGlyph(text, nextUnignorable)) {
                    font = f;
                    break;
                }
            }
            if (font != null) {
                UnicodeScript? unicodeScript = NextSignificantUnicodeScript(nextUnignorable);
                int to = nextUnignorable;
                for (int i = nextUnignorable; i < text.Length; i++) {
                    int codePoint = text.CodePointAt(i);
                    UnicodeScript? currScript = iText.IO.Util.UnicodeScriptUtil.Of(codePoint);
                    if (IsSignificantUnicodeScript(currScript) && currScript != unicodeScript) {
                        break;
                    }
                    if (IsSurrogatePair(codePoint)) {
                        i++;
                    }
                    to = i;
                }
                index += font.AppendGlyphs(text, index, to, glyphs);
            }
            else {
                font = selector.BestMatch();
                if (index != nextUnignorable) {
                    index += font.AppendGlyphs(text, index, nextUnignorable - 1, glyphs);
                }
                index += font.AppendAnyGlyph(text, nextUnignorable, glyphs);
            }
            return glyphs;
        }

        protected internal virtual int NextUnignorableIndex() {
            int nextValidChar = index;
            for (; nextValidChar < text.Length; nextValidChar++) {
                if (!iText.IO.Util.TextUtil.IsIdentifierIgnorable(text[nextValidChar])) {
                    break;
                }
            }
            return nextValidChar;
        }

        protected internal virtual UnicodeScript? NextSignificantUnicodeScript(int from) {
            for (int i = from; i < text.Length; i++) {
                int codePoint = text.CodePointAt(i);
                UnicodeScript? unicodeScript = iText.IO.Util.UnicodeScriptUtil.Of(codePoint);
                if (IsSignificantUnicodeScript(unicodeScript)) {
                    return unicodeScript;
                }
                if (IsSurrogatePair(codePoint)) {
                    i++;
                }
            }
            return UnicodeScript.COMMON;
        }

        private static bool IsSignificantUnicodeScript(UnicodeScript? unicodeScript) {
            // Character.UnicodeScript.UNKNOWN will be handled as significant unicode script
            return unicodeScript != UnicodeScript.COMMON && unicodeScript != UnicodeScript.INHERITED;
        }

        private static bool IsSurrogatePair(int codePoint) {
            //lazy surrogate pair check
            return codePoint > 0xFFFF;
        }
    }
}
