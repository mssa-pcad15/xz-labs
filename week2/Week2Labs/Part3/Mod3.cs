using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
    internal class Mod3
    {
        //internal static void SwitchCase() {
        //    int employeeLevel = 100;
        //    string employeeName = "John Smith";

        //    string title = "";

        //    switch (employeeLevel)
        //    {
        //        case 100:
        //            title = "Junior Associate";
        //            break;

        //        case 200:
        //            title = "Senior Associate";
        //            break;

        //        case 300:
        //            title = "Manager";
        //            break;

        //        case 400:
        //            title = "Senior Manager";
        //            break;

        //        default:
        //            title = "Associate";
        //            break;
        //    }
        //    Console.WriteLine($"{employeeName}, {title}");
        //}

        internal static void Challenge()
        {
            // SKU = Stock Keeping Unit. 
            // SKU value format: <product #>-<2-letter color code>-<size code>
            string sku = "01-MN-L";

            string[] product = sku.Split('-');

            string type = "";
            string color = "";
            string size = "";

            for (int i = 0; i < product.Length; i++) {

                switch (i)
                {
                    case 0:
                        switch (product[i])
                        {
                            case "01":
                                type = "Sweat shirt";
                                break;
                            case "02":
                                type = "T-Shirt";
                                break;
                            case "03":
                                type = "Sweat pants";
                                break;
                            default:
                                type = "Other";
                                break;
                        }
                        break;

                    case 1:
                        switch (product[i]) {
                            case "BL":
                                color = "Black";
                                break;
                            case "MN":
                                color = "Maroon";
                                break;
                            default:
                                color = "White";
                                break;
                        }
                        break;

                    case 2:
                        switch (product[i])
                        {
                            case "S":
                                size = "Small";
                                break;

                            case "M":
                                size = "Medium";
                                break;

                            case "L":
                                size = "Large";
                                break;

                            default:
                                size = "One Size Fits All";
                                break;
                        }
                        break;
                }
            }



            Console.WriteLine($"Product: {size} {color} {type}");


        }

            

        }
    }

