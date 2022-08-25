/*

This file is part of the iText (R) project.
Copyright (c) 1998-2022 iText Group NV
Authors: Bruno Lowagie, Paulo Soares, et al.

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
using iText.Layout;
using iText.Layout.Element;

namespace iText.Layout.Properties {
    /// <summary>
    /// A specialized enum holding the possible values
    /// for a list
    /// <see cref="List"/>
    /// 's entry prefix.
    /// </summary>
    /// <remarks>
    /// A specialized enum holding the possible values
    /// for a list
    /// <see cref="List"/>
    /// 's entry prefix.
    /// This class is meant to be used as the value for the
    /// <see cref="Property.LIST_SYMBOL"/>
    /// key
    /// in an
    /// <see cref="IPropertyContainer"/>.
    /// </remarks>
    public enum ListNumberingType {
        DECIMAL,
        DECIMAL_LEADING_ZERO,
        ROMAN_LOWER,
        ROMAN_UPPER,
        ENGLISH_LOWER,
        ENGLISH_UPPER,
        GREEK_LOWER,
        GREEK_UPPER,
        /// <summary>Zapfdingbats font characters in range [172; 181]</summary>
        ZAPF_DINGBATS_1,
        /// <summary>Zapfdingbats font characters in range [182; 191]</summary>
        ZAPF_DINGBATS_2,
        /// <summary>Zapfdingbats font characters in range [192; 201]</summary>
        ZAPF_DINGBATS_3,
        /// <summary>Zapfdingbats font characters in range [202; 221]</summary>
        ZAPF_DINGBATS_4
    }
}
