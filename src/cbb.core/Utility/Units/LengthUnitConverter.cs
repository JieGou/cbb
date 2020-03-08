namespace cbb.core
{
    using System;

    /// <summary>
    /// The helper functions for converting length units in desired type.
    /// </summary>
    public static class LengthUnitConverter
    {
        #region public methods

        /// <summary>
        /// Converts internal imperial units to metric length units.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type of unit to convert to.</param>
        /// <param name="decimals">The decimal spaces precision.</param>
        /// <returns></returns>
        public static double ConvertToMetric(double value, LengthUnitType type, int decimals)
        {
            switch (type)
            {
                case LengthUnitType.Milimeter:
                    return Math.Round(value * 304.8, decimals);

                case LengthUnitType.Centimeter:
                    return Math.Round(value * 30.48, decimals);

                case LengthUnitType.Decimeter:
                    return Math.Round(value * 3.048, decimals);

                case LengthUnitType.Meter:
                    return Math.Round(value * 0.3048, decimals);

                case LengthUnitType.Kilometer:
                    return Math.Round(value * 0.0003048, decimals);

                default:
                    return value;
            }
        }

        #endregion public methods
    }
}