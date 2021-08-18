/*
This file is part of the iText (R) project.
Copyright (c) 1998-2021 iText Group NV
Authors: iText Software.

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
using System;

namespace iText.Events.Data {
    /// <summary>Class is used to describe used product information.</summary>
    public sealed class ProductData {
        private readonly String publicProductName;

        private readonly String productName;

        private readonly String version;

        private readonly int sinceCopyrightYear;

        private readonly int toCopyrightYear;

        /// <summary>Creates a new instance of product data.</summary>
        /// <param name="publicProductName">is a product name</param>
        /// <param name="productName">is a technical name of the product</param>
        /// <param name="version">is a version of the product</param>
        /// <param name="sinceCopyrightYear">is the first year of a product development</param>
        /// <param name="toCopyrightYear">is a last year of a product development</param>
        public ProductData(String publicProductName, String productName, String version, int sinceCopyrightYear, int
             toCopyrightYear) {
            this.publicProductName = publicProductName;
            this.productName = productName;
            this.version = version;
            this.sinceCopyrightYear = sinceCopyrightYear;
            this.toCopyrightYear = toCopyrightYear;
        }

        /// <summary>Getter for a product name.</summary>
        /// <returns>product name</returns>
        public String GetPublicProductName() {
            return publicProductName;
        }

        /// <summary>Getter for a technical name of the product.</summary>
        /// <returns>the technical name of the product</returns>
        public String GetProductName() {
            return productName;
        }

        /// <summary>Getter for a version of the product</summary>
        /// <returns>version of the product</returns>
        public String GetVersion() {
            return version;
        }

        /// <summary>Getter for the first year of copyright period.</summary>
        /// <returns>the first year of copyright</returns>
        public int GetSinceCopyrightYear() {
            return sinceCopyrightYear;
        }

        /// <summary>Getter for the last year of copyright period</summary>
        /// <returns>the last year of copyright</returns>
        public int GetToCopyrightYear() {
            return toCopyrightYear;
        }
    }
}