namespace CustomerManagementModule.Models
{
    public abstract class DataModel
    {
        public string Id { get; set; }
        public bool IsNew { get; set; }

        private bool _isDirty;
        public bool IsDirty
        {
            get => _isDirty;
            protected set => _isDirty = value;
        }

        protected void MarkDirty() => IsDirty = _isDirty;
    }
}
