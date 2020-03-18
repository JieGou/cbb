namespace cbb.core
{
    using GalaSoft.MvvmLight;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Preferences options stored in this data model.
    /// </summary>
    public class Preferences : ViewModelBase
    {
        #region private members

        /// <summary>
        /// The preferences file name.
        /// </summary>
        private string file = "prefs.cbb";

        #endregion private members

        #region public properties

        /// <summary>
        /// Gets or sets the repository locations.
        /// </summary>
        /// <value>
        /// The repository directories.
        /// </value>
        //public List<string> Repository { get; set; }

        /// <summary>
        /// The <see cref="Repository" /> property's name.
        /// </summary>
        public const string RepositoryPropertyName = "Repository";

        private List<string> _repository;

        /// <summary>
        /// Sets and gets the Repository property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public List<string> Repository
        {
            get => _repository;

            set
            {
                if (_repository == value)
                {
                    return;
                }

                _repository = value;
                RaisePropertyChanged(RepositoryPropertyName);
            }
        }

        #endregion public properties

        #region constructor

        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="Preferences"/> class.
        /// </summary>
        public Preferences()
        {
        }

        #endregion constructor

        #region public methods

        /// <summary>
        /// Saves this instance of preferences in the .cbb file as xml structured data.
        /// </summary>
        public void Save()
        {
            // Store file in the location relative to the core executing assembly.
            var dataFile = Path.Combine(Path.GetDirectoryName(CoreAssembly.GetAssemblyLocation().ToString()), file);

            using (var stream = new FileStream(dataFile, FileMode.Create))
            {
                // Serialize state of the object in the file.
                var serializer = new XmlSerializer(typeof(Preferences));
                serializer.Serialize(stream, this);

                this.RaisePropertyChanged(RepositoryPropertyName);
            }
        }

        /// <summary>
        /// Loads this instance data from serialized file.
        /// </summary>
        /// <returns></returns>
        public static Preferences Load()
        {
            var dataFile = Path.Combine(Path.GetDirectoryName(CoreAssembly.GetAssemblyLocation().ToString()), "prefs.cbb");

            using (var stream = new FileStream(dataFile, FileMode.Open))
            {
                // Loads saved serialized data and return it as Preferences object.
                var deserializer = new XmlSerializer(typeof(Preferences));
                var preferences = (Preferences)deserializer.Deserialize(stream);

                return preferences;
            }
        }

        #endregion public methods
    }
}