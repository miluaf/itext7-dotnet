/*
This file is part of the iText (R) project.
Copyright (c) 1998-2024 Apryse Group NV
Authors: Apryse Software.

This program is offered under a commercial and under the AGPL license.
For commercial licensing, contact us at https://itextpdf.com/sales.  For AGPL licensing, see below.

AGPL licensing:
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using iText.Test;
using iText.Test.Attributes;

namespace iText.Kernel.Pdf {
    [NUnit.Framework.Category("UnitTest")]
    public class PdfNumberTest : ExtendedITextTest {
        private const double DELTA = 0.0001;

        [NUnit.Framework.Test]
        [LogMessage(iText.IO.Logs.IoLogMessageConstant.ATTEMPT_PROCESS_NAN)]
        public virtual void TestNaN() {
            PdfNumber number = new PdfNumber(double.NaN);
            // code for "0"
            byte[] expected = new byte[] { 48 };
            NUnit.Framework.Assert.AreEqual(expected, number.GetInternalContent());
        }

        [NUnit.Framework.Test]
        public virtual void IntValueInPdfNumberTest() {
            double valueToSet = 3000000000d;
            PdfNumber number = new PdfNumber(valueToSet);
            NUnit.Framework.Assert.AreEqual(valueToSet, number.GetValue(), DELTA);
            NUnit.Framework.Assert.AreEqual(valueToSet, number.DoubleValue(), DELTA);
            NUnit.Framework.Assert.AreEqual(int.MaxValue, number.IntValue());
            valueToSet = 50d;
            number.SetValue(valueToSet + DELTA);
            NUnit.Framework.Assert.AreEqual(50, number.IntValue());
        }
    }
}
