using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codebase.Website.Models
{
    public class ProductsServicesViewModel
    {
        private int _StartIndex = 1;

        public ProductsServicesViewModel(string value)
        {
            this._StartIndex = this.GetStartIndex(value);
        }

        public int StartIndex
        {
            get { return this._StartIndex; }
        }

        private int GetStartIndex(string value)
        {
            int startIndex = 1;

            if (!string.IsNullOrEmpty(value))
            {
                switch (value.ToLower().Trim())
                {
                    case "business-cash-advance":
                        startIndex = 2;
                        break;
                    case "virtual-terminal":
                        startIndex = 3;
                        break;
                    case "gift-cards":
                        startIndex = 4;
                        break;
                    case "loyalty-reward-cards":
                        startIndex = 5;
                        break;
                    case "atm-retail-program":
                        startIndex = 6;
                        break;                    
                    case "pos-retail-systems":
                    case "e-commerce":
                    case "pci-compliance":
                        startIndex = 7;
                        break;
                    case "online-reporting":
                    case "check-21-ach":
                    case "quickbooks-solutions":
                    case "more-products-services":
                        startIndex = 8;
                        break;
                    default:
                        startIndex = 1;
                        break;
                }
            }

            //if (!string.IsNullOrEmpty(value))
            //{
            //    switch (value.ToLower().Trim())
            //    {
            //        case "business-cash-advance":
            //            startIndex = 2;
            //            break;
            //        case "virtual-terminal":
            //            startIndex = 3;
            //            break;
            //        case "atm-retail-program":
            //            startIndex = 4;
            //            break;
            //        case "credit-debit-cards":
            //        case "gift-loyalty-cards":                    
            //        case "wireless-terminal":
            //            startIndex = 5;
            //            break;
            //        case "pos-retail-systems":
            //        case "e-commerce":
            //        case "pci-compliance":
            //            startIndex = 6;
            //            break;
            //        case "online-reporting":
            //        case "check-21-ach":
            //        case "quickbooks-solutions":
            //        case "more-products-services":
            //            startIndex = 7;
            //            break;                                        
            //        default:
            //            startIndex = 1;
            //            break;
            //    }
            //}

            return startIndex;
        }

        //// 2012-07-06: The order was changed.
        //private int GetStartIndex(string value)
        //{
        //    int startIndex = 1;

        //    if (!string.IsNullOrEmpty(value))
        //    {
        //        switch (value.ToLower().Trim())
        //        {
        //            case "credit-debit-cards":
        //            case "gift-loyalty-cards":
        //            case "virtual-terminal":
        //                startIndex = 1;
        //                break;
        //            case "business-cash-advance":
        //            case "check-21-ach":
        //            case "quickbooks-solutions":
        //                startIndex = 2;
        //                break;
        //            case "pos-retail-systems":
        //            case "e-commerce":
        //            case "pci-compliance":
        //                startIndex = 3;
        //                break;
        //            case "more-products-services":
        //            case "wireless-terminal":
        //            case "online-reporting":
        //            case "atm-processing":
        //                startIndex = 4;
        //                break;
        //            default:
        //                startIndex = 1;
        //                break;
        //        }
        //    }

        //    return startIndex;
        //}
    }
}