using System.ComponentModel;

namespace cbb.core
{
    /// <summary>
    /// Length unit type.
    /// </summary>
    public enum LengthUnitType
    {
        /// <summary>
        /// The milimeter unit.
        /// </summary>
        [Description("毫米")]
        Milimeter = 0,

        /// <summary>
        /// The centimeter unit.
        /// </summary>
        [Description("厘米")]
        Centimeter = 1,

        /// <summary>
        /// The decimeter unit.
        /// </summary>
        [Description("分米")]
        Decimeter = 2,

        /// <summary>
        /// The meter unit.
        /// </summary>
        [Description("米")]
        Meter = 3,

        /// <summary>
        /// The kilometer unit.
        /// </summary>
        [Description("千米")]
        Kilometer = 4,
    }
}