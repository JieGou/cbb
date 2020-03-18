namespace cbb.core
{
    using GalaSoft.MvvmLight;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Repository list view model for list view in ui control.
    /// </summary>
    /// <seealso cref="cbb.core.BaseViewModel" />
    public class RepositoryListViewModel : ViewModelBase
    {
        #region public properties

        /// <summary>
        /// Gets or sets the repository items.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        //public ObservableCollection<RepositoryItem> Repository { get; set; }

        /// <summary>
        /// The <see cref="Repository" /> property's name.
        /// </summary>
        public const string RepositoryPropertyName = "Repository";

        private ObservableCollection<RepositoryItem> _repository;

        /// <summary>
        /// Sets and gets the Repository property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public ObservableCollection<RepositoryItem> Repository
        {
            get
            {
                return _repository;
            }

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
        /// Initializes a new instance of the <see cref="RepositoryListViewModel"/> class.
        /// </summary>
        public RepositoryListViewModel()
        {
            // Populate list on object construction time.
            Repository = GetRepositories();
        }

        #endregion constructor

        #region private methods

        /// <summary>
        /// Gets the repository items.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<RepositoryItem> GetRepositories()
        {
            // Empty container to populate and return.
            var items = new ObservableCollection<RepositoryItem>();

            // Load exsisting preferences from serialized file.
            var prefs = Preferences.Load();

            // Loads data from file.
            foreach (var path in prefs.Repository)
            {
                var repository = new RepositoryItem
                {
                    FullPath = path,
                };
                items.Add(repository);
            }

            return items;
        }

        #endregion private methods
    }
}