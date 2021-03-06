﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Math
{
    public partial class ArithmeticHelpers
    {
        public static T Addition<T>(T lhs, T rhs)
            #if !NETSTANDARD1_0
            where T : IConvertible
            #endif
        {
            Type precision = typeof(double);

            return Addition(lhs, rhs, precision);
        }

        public static T Addition<T>(T lhs, T rhs, Type precision)
            #if !NETSTANDARD1_0
            where T : IConvertible
            #endif
        {
            if (precision == typeof(decimal))
            {
                decimal lhs_decimal =
                           (decimal)Convert.ChangeType(lhs, typeof(decimal))
                            //lhs.ToDecimal(CultureInfo.CurrentCulture)
                            ;
                decimal rhs_decimal =
                            (decimal)Convert.ChangeType(rhs, typeof(decimal))
                            //rhs.ToDecimal(CultureInfo.CurrentCulture)
                            ;

                //System.Runtime.Extensions
                return (T)Convert.ChangeType(lhs_decimal + rhs_decimal, typeof(T));
            }
            else
            {
                throw new NotSupportedException("Type not supported");
            }

            return default(T);
        }
    }

}
