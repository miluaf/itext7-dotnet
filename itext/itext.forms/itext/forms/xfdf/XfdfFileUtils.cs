/*
This file is part of the iText (R) project.
Copyright (c) 1998-2019 iText Group NV
Authors: iText Software.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License version 3
as published by the Free Software Foundation with the addition of the
following permission added to Section 15 as permitted in Section 7(a):
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
OF THIRD PARTY RIGHTS

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program; if not, see http://www.gnu.org/licenses or write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
Boston, MA, 02110-1301 USA, or download the license from the following URL:
http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions
of this program must display Appropriate Legal Notices, as required under
Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License,
a covered work must retain the producer line in every PDF that is created
or manipulated using iText.

You can be released from the requirements of the license by purchasing
a commercial license. Buying such a license is mandatory as soon as you
develop commercial activities involving the iText software without
disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP,
serving PDFs on the fly in a web application, shipping iText with a closed
source product.

For more information, please contact iText Software Corp. at this
address: sales@itextpdf.com
*/
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using iText.Layout.Properties;

namespace iText.Forms.Xfdf {
    internal sealed class XfdfFileUtils {
        private XfdfFileUtils() {
        }

        /// <exception cref="Javax.Xml.Parsers.ParserConfigurationExcep tion"/>
        internal static XmlDocument CreateNewXfdfDocument() {
            return new XmlDocument();
        }

        /// <exception cref="Javax.Xml.Parsers.ParserConfigurationException"/>
        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="Org.Xml.Sax.SAXException"/>
        internal static XmlDocument CreateXfdfDocumentFromStream(Stream  inputStream) {
            XmlDocument doc = new XmlDocument();
            doc.Load(createSafeReader(inputStream));
            return doc;
        }

        /// <exception cref="Transform.TransformerException"/>
        internal static void SaveXfdfDocumentToFile(XmlDocument document, Stream outputStream) {
           document.Save(outputStream);
           outputStream.Dispose();
        }

        private static XmlReader createSafeReader(Stream str) {
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.DtdProcessing = DtdProcessing.Ignore;
            XmlReader reader = XmlReader.Create(str, xmlReaderSettings);
            try {
                // Prevents Exception "Reference to undeclared entity 'question'"
                PropertyInfo propertyInfo = reader.GetType().GetProperty("DisableUndeclaredEntityCheck",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                propertyInfo.SetValue(reader, true, null);
            } catch (Exception exc) {
            }
            return reader;
        }
    }
}