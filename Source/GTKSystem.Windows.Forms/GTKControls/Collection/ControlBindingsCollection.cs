using System.Collections;
using System.ComponentModel;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace System.Windows.Forms
{
	[DefaultEvent("CollectionChanged")]
	public class ControlBindingsCollection : BindingsCollection
    {
        private Control _owner;
        private ListBox _listBox;
        private DataGridView _dataGridView;
        public ControlBindingsCollection(ListBox owner):base(owner) {
			_owner = owner;
			_listBox = owner;
        }
        public ControlBindingsCollection(DataGridView owner) : base(owner)
        {
            _owner = owner;
			_dataGridView = owner;
        }
        public IBindableComponent BindableComponent
		{
			get
			{
				throw null;
			}
		}

		public Control Control
		{
			get => _owner;
		}

		public Binding this[string propertyName]
		{
			get
			{
				foreach (Binding binding in this)
				{
					if(binding.PropertyName == propertyName)
						return binding;
				}
				return null;
			}
		}

		public DataSourceUpdateMode DefaultDataSourceUpdateMode
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public ControlBindingsCollection(IBindableComponent control)
        {
        }
        public new void Add(Binding binding)
        {
			base.Add(binding);
            if (_listBox != null)
                _listBox.BindDataSource(binding.DataSource, binding.DataMember, binding.DataMember, _listBox.SelectedIndex, binding.FormattingEnabled, binding.DataSourceUpdateMode, binding.NullValue, binding.FormatString);
            if (_dataGridView != null)
                _dataGridView.BindDataSource(binding.DataSource, binding.DataMember, binding.DataMember, _listBox.SelectedIndex, binding.FormattingEnabled, binding.DataSourceUpdateMode, binding.NullValue, binding.FormatString);

        }
        public Binding Add(string propertyName, object dataSource, string dataMember)
		{
            return Add(propertyName, dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged, null, null, null);
        }

		public Binding Add(string propertyName, object dataSource, string dataMember, bool formattingEnabled)
		{
            return Add(propertyName, dataSource, dataMember, formattingEnabled, DataSourceUpdateMode.OnPropertyChanged, null, null, null);
        }

		public Binding Add(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode updateMode)
		{
            return Add(propertyName, dataSource, dataMember, formattingEnabled, updateMode, null, null,null);
        }

        public Binding Add(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode updateMode, object nullValue)
		{
            return Add(propertyName, dataSource, dataMember, formattingEnabled, updateMode, nullValue, null,null);
        }

        public Binding Add(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode updateMode, object nullValue, string formatString)
		{
			return Add(propertyName, dataSource, dataMember, formattingEnabled, updateMode, nullValue, formatString,null);
        }

		public Binding Add(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode updateMode, object nullValue, string formatString, IFormatProvider formatInfo)
		{
            Binding binding = new Binding(propertyName,dataSource, dataMember, formattingEnabled, updateMode, nullValue, formatString, formatInfo);
			this.Add(binding);
			return binding;
		}
	}
}
