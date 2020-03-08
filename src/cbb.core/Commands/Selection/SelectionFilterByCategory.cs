namespace cbb.core
{
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI.Selection;

    /// <summary>
    /// Selection filter based on the user provided category name.
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.Selection.ISelectionFilter" />
    public class SelectionFilterByCategory : ISelectionFilter
    {
        #region private members

        /// <summary>
        ///  Private variable that holds category name.
        /// </summary>
        private string _mCategory;

        /// <summary>
        /// 内置类型
        /// </summary>
        private BuiltInCategory _builtInCategory;

        #endregion private members

        #region constructor

        /// <summary>
        /// 新增构造方法.
        /// Initializes a new instance of the <see cref="SelectionFilterByCategory"/> class.
        /// </summary>
        /// <param name="builtInCategory">内置类型 如BuiltInCategory.OST_Walls</param>
        /// <remarks>
        /// 考虑直接使用Category名称会由于语言影响使用，故加此构造方法
        /// </remarks>
        public SelectionFilterByCategory(BuiltInCategory builtInCategory)
        {
            _builtInCategory = builtInCategory;
        }

        /// <summary>
        /// default constrauctor.
        /// Initializes a new instance of the <see cref="SelectionFilterByCategory"/> class.
        /// </summary>
        /// <param name="category">The category of element, suche as Walls, Floors,...</param>
        public SelectionFilterByCategory(string category)
        {
            _mCategory = category;
        }

        #endregion constructor

        #region public methods

        /// <summary>
        /// Allows the element selection if provided category is equal to selected one.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool AllowElement(Element element)
        {
            //有语言的影响
            var builtInCategory = (BuiltInCategory)element.Category.Id.IntegerValue;

            // Check if category matches.
            if (element.Category.Name == _mCategory
                || builtInCategory == _builtInCategory)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Allows the reference.
        /// </summary>
        /// <param name="reference">The reference.</param>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }

        #endregion public methods
    }
}