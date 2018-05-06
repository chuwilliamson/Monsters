namespace Cinemachine
{
    /// <summary>
    /// Atrtribute to control the automatic generation of documentation.
    /// </summary>
    [DocumentationSorting(0f, DocumentationSortingAttribute.Level.Undoc)]
    public sealed class DocumentationSortingAttribute : System.Attribute
    {
        /// <summary>Refinement level of the documentation</summary>
        public enum Level 
        { 
            /// <summary>Type is excluded from documentation</summary>
            Undoc, 
            /// <summary>Type is documented in the API reference</summary>
            API, 
            /// <summary>Type is documented in the highly-refined User Manual</summary>
            UserRef 
        };
        /// <summary>Where this type appears in the manual.  Smaller number sort earlier.</summary>
        public float SortOrder { get; private set; }
        /// <summary>Refinement level of the documentation.  The more refined, the more is excluded.</summary>
        public Level Category { get; private set; }

        /// <summary>Contructor with specific values</summary>
        public DocumentationSortingAttribute(float sortOrder, Level category)
        {
            SortOrder = sortOrder;
            Category = category;
        }
    }
}