using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

 
namespace System.Windows.Forms
{

	[DefaultEvent("SelectedIndexChanged")]
	public class ListView : ListBox
    {
 
		[ListBindable(false)]
		public class CheckedIndexCollection : IList, ICollection, IEnumerable
		{
			[Browsable(false)]
			public int Count
			{
				get
				{
					throw null;
				}
			}

			public int this[int index]
			{
				get
				{
					throw null;
				}
			}

			object? IList.this[int index]
			{
				get
				{
					throw null;
				}
				set
				{
					throw null;
				}
			}

			object ICollection.SyncRoot
			{
				get
				{
					throw null;
				}
			}

			bool ICollection.IsSynchronized
			{
				get
				{
					throw null;
				}
			}

			bool IList.IsFixedSize
			{
				get
				{
					throw null;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					throw null;
				}
			}

			public CheckedIndexCollection(ListView owner)
			{
				throw null;
			}

			public bool Contains(int checkedIndex)
			{
				throw null;
			}

			bool IList.Contains(object? checkedIndex)
			{
				throw null;
			}

			public int IndexOf(int checkedIndex)
			{
				throw null;
			}

			int IList.IndexOf(object? checkedIndex)
			{
				throw null;
			}

			int IList.Add(object? value)
			{
				throw null;
			}

			void IList.Clear()
			{
				throw null;
			}

			void IList.Insert(int index, object? value)
			{
				throw null;
			}

			void IList.Remove(object? value)
			{
				throw null;
			}

			void IList.RemoveAt(int index)
			{
				throw null;
			}

			void ICollection.CopyTo(Array dest, int index)
			{
				throw null;
			}

			public IEnumerator GetEnumerator()
			{
				throw null;
			}
		}

		[ListBindable(false)]
		public class CheckedListViewItemCollection : IList, ICollection, IEnumerable
		{
			[Browsable(false)]
			public int Count
			{
				get
				{
					throw null;
				}
			}

			public ListViewItem this[int index]
			{
				get
				{
					throw null;
				}
			}

			object? IList.this[int index]
			{
				get
				{
					throw null;
				}
				set
				{
					throw null;
				}
			}

			public virtual ListViewItem? this[string? key]
			{
				get
				{
					throw null;
				}
			}

			object ICollection.SyncRoot
			{
				get
				{
					throw null;
				}
			}

			bool ICollection.IsSynchronized
			{
				get
				{
					throw null;
				}
			}

			bool IList.IsFixedSize
			{
				get
				{
					throw null;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					throw null;
				}
			}

			public CheckedListViewItemCollection(ListView owner)
			{
				throw null;
			}

			public bool Contains(ListViewItem? item)
			{
				throw null;
			}

			bool IList.Contains(object? item)
			{
				throw null;
			}

			public virtual bool ContainsKey(string? key)
			{
				throw null;
			}

			public int IndexOf(ListViewItem item)
			{
				throw null;
			}

			public virtual int IndexOfKey(string? key)
			{
				throw null;
			}

			int IList.IndexOf(object? item)
			{
				throw null;
			}

			int IList.Add(object? value)
			{
				throw null;
			}

			void IList.Clear()
			{
				throw null;
			}

			void IList.Insert(int index, object? value)
			{
				throw null;
			}

			void IList.Remove(object? value)
			{
				throw null;
			}

			void IList.RemoveAt(int index)
			{
				throw null;
			}

			public void CopyTo(Array dest, int index)
			{
				throw null;
			}

			public IEnumerator GetEnumerator()
			{
				throw null;
			}
		}

		[ListBindable(false)]
		public class ColumnHeaderCollection : IList, ICollection, IEnumerable
		{
			public virtual ColumnHeader this[int index]
			{
				get
				{
					throw null;
				}
			}

			object? IList.this[int index]
			{
				get
				{
					throw null;
				}
				set
				{
					throw null;
				}
			}

			public virtual ColumnHeader? this[string? key]
			{
				get
				{
					throw null;
				}
			}

			[Browsable(false)]
			public int Count
			{
				get
				{
					throw null;
				}
			}

			object ICollection.SyncRoot
			{
				get
				{
					throw null;
				}
			}

			bool ICollection.IsSynchronized
			{
				get
				{
					throw null;
				}
			}

			bool IList.IsFixedSize
			{
				get
				{
					throw null;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					throw null;
				}
			}

			public ColumnHeaderCollection(ListView owner)
			{
				throw null;
			}

			public virtual void RemoveByKey(string? key)
			{
				throw null;
			}

			public virtual int IndexOfKey(string? key)
			{
				throw null;
			}

			public virtual ColumnHeader Add(string? text, int width, HorizontalAlignment textAlign)
			{
				throw null;
			}

			public virtual int Add(ColumnHeader value)
			{
				throw null;
			}

			public virtual ColumnHeader Add(string? text)
			{
				throw null;
			}

			public virtual ColumnHeader Add(string? text, int width)
			{
				throw null;
			}

			public virtual ColumnHeader Add(string? key, string? text)
			{
				throw null;
			}

			public virtual ColumnHeader Add(string? key, string? text, int width)
			{
				throw null;
			}

			public virtual ColumnHeader Add(string? key, string? text, int width, HorizontalAlignment textAlign, string imageKey)
			{
				throw null;
			}

			public virtual ColumnHeader Add(string? key, string? text, int width, HorizontalAlignment textAlign, int imageIndex)
			{
				throw null;
			}

			public virtual void AddRange(ColumnHeader[] values)
			{
				throw null;
			}

			int IList.Add(object? value)
			{
				throw null;
			}

			public virtual void Clear()
			{
				throw null;
			}

			public bool Contains(ColumnHeader? value)
			{
				throw null;
			}

			bool IList.Contains(object? value)
			{
				throw null;
			}

			public virtual bool ContainsKey(string? key)
			{
				throw null;
			}

			void ICollection.CopyTo(Array dest, int index)
			{
				throw null;
			}

			public int IndexOf(ColumnHeader? value)
			{
				throw null;
			}

			int IList.IndexOf(object? value)
			{
				throw null;
			}

			public void Insert(int index, ColumnHeader value)
			{
				throw null;
			}

			void IList.Insert(int index, object? value)
			{
				throw null;
			}

			public void Insert(int index, string? text, int width, HorizontalAlignment textAlign)
			{
				throw null;
			}

			public void Insert(int index, string? text)
			{
				throw null;
			}

			public void Insert(int index, string? text, int width)
			{
				throw null;
			}

			public void Insert(int index, string? key, string? text)
			{
				throw null;
			}

			public void Insert(int index, string? key, string? text, int width)
			{
				throw null;
			}

			public void Insert(int index, string? key, string? text, int width, HorizontalAlignment textAlign, string imageKey)
			{
				throw null;
			}

			public void Insert(int index, string? key, string? text, int width, HorizontalAlignment textAlign, int imageIndex)
			{
				throw null;
			}

			public virtual void RemoveAt(int index)
			{
				throw null;
			}

			public virtual void Remove(ColumnHeader column)
			{
				throw null;
			}

			void IList.Remove(object? value)
			{
				throw null;
			}

			public IEnumerator GetEnumerator()
			{
				throw null;
			}
		}
 
		[ListBindable(false)]
		public class ListViewItemCollection : IList, ICollection, IEnumerable
		{
			internal interface IInnerList
			{
				int Count { get; }

				bool OwnerIsVirtualListView { get; }

				bool OwnerIsDesignMode { get; }

				ListViewItem this[int index] { get; set; }

				ListViewItem Add(ListViewItem item);

				void AddRange(ListViewItem[] items);

				void Clear();

				bool Contains(ListViewItem item);

				void CopyTo(Array dest, int index);

				IEnumerator GetEnumerator();

				int IndexOf(ListViewItem item);

				ListViewItem Insert(int index, ListViewItem item);

				void Remove(ListViewItem item);

				void RemoveAt(int index);
			}

			[Browsable(false)]
			public int Count
			{
				get
				{
					throw null;
				}
			}

			object ICollection.SyncRoot
			{
				get
				{
					throw null;
				}
			}

			bool ICollection.IsSynchronized
			{
				get
				{
					throw null;
				}
			}

			bool IList.IsFixedSize
			{
				get
				{
					throw null;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					throw null;
				}
			}

			public virtual ListViewItem this[int index]
			{
				get
				{
					throw null;
				}
				set
				{
					throw null;
				}
			}

			object? IList.this[int index]
			{
				get
				{
					throw null;
				}
				set
				{
					throw null;
				}
			}

			public virtual ListViewItem? this[string key]
			{
				get
				{
					throw null;
				}
			}

			public ListViewItemCollection(ListView owner)
			{
				throw null;
			}

			internal ListViewItemCollection(IInnerList innerList)
			{
				throw null;
			}

			public virtual ListViewItem Add(string? text)
			{
				throw null;
			}

			int IList.Add(object? item)
			{
				throw null;
			}

			public virtual ListViewItem Add(string? text, int imageIndex)
			{
				throw null;
			}

			public virtual ListViewItem Add(ListViewItem value)
			{
				throw null;
			}

			public virtual ListViewItem Add(string? text, string? imageKey)
			{
				throw null;
			}

			public virtual ListViewItem Add(string? key, string? text, string? imageKey)
			{
				throw null;
			}

			public virtual ListViewItem Add(string? key, string? text, int imageIndex)
			{
				throw null;
			}

			public void AddRange(ListViewItem[] items)
			{
				throw null;
			}

			public void AddRange(ListViewItemCollection items)
			{
				throw null;
			}

			public virtual void Clear()
			{
				throw null;
			}

			public bool Contains(ListViewItem item)
			{
				throw null;
			}

			bool IList.Contains(object? item)
			{
				throw null;
			}

			public virtual bool ContainsKey(string? key)
			{
				throw null;
			}

			public void CopyTo(Array dest, int index)
			{
				throw null;
			}

			public ListViewItem[] Find(string key, bool searchAllSubItems)
			{
				throw null;
			}

			public IEnumerator GetEnumerator()
			{
				throw null;
			}

			public int IndexOf(ListViewItem item)
			{
				throw null;
			}

			int IList.IndexOf(object? item)
			{
				throw null;
			}

			public virtual int IndexOfKey(string? key)
			{
				throw null;
			}

			public ListViewItem Insert(int index, ListViewItem item)
			{
				throw null;
			}

			public ListViewItem Insert(int index, string? text)
			{
				throw null;
			}

			public ListViewItem Insert(int index, string? text, int imageIndex)
			{
				throw null;
			}

			void IList.Insert(int index, object? item)
			{
				throw null;
			}

			public ListViewItem Insert(int index, string? text, string? imageKey)
			{
				throw null;
			}

			public virtual ListViewItem Insert(int index, string? key, string? text, string? imageKey)
			{
				throw null;
			}

			public virtual ListViewItem Insert(int index, string? key, string? text, int imageIndex)
			{
				throw null;
			}

			public virtual void Remove(ListViewItem item)
			{
				throw null;
			}

			public virtual void RemoveAt(int index)
			{
				throw null;
			}

			public virtual void RemoveByKey(string key)
			{
				throw null;
			}

			void IList.Remove(object? item)
			{
				throw null;
			}
		}
 
		[ListBindable(false)]
		public class SelectedIndexCollection : IList, ICollection, IEnumerable
		{
			[Browsable(false)]
			public int Count
			{
				get
				{
					throw null;
				}
			}

			public int this[int index]
			{
				get
				{
					throw null;
				}
			}

			object? IList.this[int index]
			{
				get
				{
					throw null;
				}
				set
				{
					throw null;
				}
			}

			object ICollection.SyncRoot
			{
				get
				{
					throw null;
				}
			}

			bool ICollection.IsSynchronized
			{
				get
				{
					throw null;
				}
			}

			bool IList.IsFixedSize
			{
				get
				{
					throw null;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					throw null;
				}
			}

			public SelectedIndexCollection(ListView owner)
			{
				throw null;
			}

			public bool Contains(int selectedIndex)
			{
				throw null;
			}

			bool IList.Contains(object? selectedIndex)
			{
				throw null;
			}

			public int IndexOf(int selectedIndex)
			{
				throw null;
			}

			int IList.IndexOf(object? selectedIndex)
			{
				throw null;
			}

			int IList.Add(object? value)
			{
				throw null;
			}

			void IList.Clear()
			{
				throw null;
			}

			void IList.Insert(int index, object? value)
			{
				throw null;
			}

			void IList.Remove(object? value)
			{
				throw null;
			}

			void IList.RemoveAt(int index)
			{
				throw null;
			}

			public int Add(int itemIndex)
			{
				throw null;
			}

			public void Clear()
			{
				throw null;
			}

			public void CopyTo(Array dest, int index)
			{
				throw null;
			}

			public IEnumerator GetEnumerator()
			{
				throw null;
			}

			public void Remove(int itemIndex)
			{
				throw null;
			}
		}

		[ListBindable(false)]
		public class SelectedListViewItemCollection : IList, ICollection, IEnumerable
		{
			[Browsable(false)]
			public int Count
			{
				get
				{
					throw null;
				}
			}

			public ListViewItem this[int index]
			{
				get
				{
					throw null;
				}
			}

			public virtual ListViewItem? this[string? key]
			{
				get
				{
					throw null;
				}
			}

			object? IList.this[int index]
			{
				get
				{
					throw null;
				}
				set
				{
					throw null;
				}
			}

			bool IList.IsFixedSize
			{
				get
				{
					throw null;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					throw null;
				}
			}

			object ICollection.SyncRoot
			{
				get
				{
					throw null;
				}
			}

			bool ICollection.IsSynchronized
			{
				get
				{
					throw null;
				}
			}

			public SelectedListViewItemCollection(ListView owner)
			{
				throw null;
			}

			int IList.Add(object? value)
			{
				throw null;
			}

			void IList.Insert(int index, object? value)
			{
				throw null;
			}

			void IList.Remove(object? value)
			{
				throw null;
			}

			void IList.RemoveAt(int index)
			{
				throw null;
			}

			public void Clear()
			{
				throw null;
			}

			public virtual bool ContainsKey(string? key)
			{
				throw null;
			}

			public bool Contains(ListViewItem? item)
			{
				throw null;
			}

			bool IList.Contains(object? item)
			{
				throw null;
			}

			public void CopyTo(Array dest, int index)
			{
				throw null;
			}

			public IEnumerator GetEnumerator()
			{
				throw null;
			}

			public int IndexOf(ListViewItem? item)
			{
				throw null;
			}

			int IList.IndexOf(object? item)
			{
				throw null;
			}

			public virtual int IndexOfKey(string? key)
			{
				throw null;
			}
		}


		public ItemActivation Activation
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}


		[Localizable(true)]
		public ListViewAlignment Alignment
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		[DefaultValue(false)]
		public bool AllowColumnReorder
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		[DefaultValue(true)]
		public bool AutoArrange
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public override Color BackColor
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override ImageLayout BackgroundImageLayout
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool BackgroundImageTiled
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public BorderStyle BorderStyle
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool CheckBoxes
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public CheckedIndexCollection CheckedIndices
		{
			get
			{
				throw null;
			}
		}

		public CheckedListViewItemCollection CheckedItems
		{
			get
			{
				throw null;
			}
		}
		public ColumnHeaderCollection Columns
		{
			get
			{
				throw null;
			}
		}

		public ListViewItem? FocusedItem
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public override Color ForeColor
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool FullRowSelect
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool GridLines
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public ImageList? GroupImageList
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public ListViewGroupCollection Groups
		{
			get
			{
				throw null;
			}
		}

		public ColumnHeaderStyle HeaderStyle
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool HideSelection
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool HotTracking
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool HoverSelection
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public ListViewInsertionMark InsertionMark
		{
			get
			{
				throw null;
			}
		}

		public ListViewItemCollection Items
		{
			get
			{
				throw null;
			}
		}

		public bool LabelEdit
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool LabelWrap
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public ImageList? LargeImageList
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public IComparer? ListViewItemSorter
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool MultiSelect
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool OwnerDraw
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}
		public virtual bool RightToLeftLayout
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool Scrollable
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public SelectedIndexCollection SelectedIndices
		{
			get
			{
				throw null;
			}
		}

		public SelectedListViewItemCollection SelectedItems
		{
			get
			{
				throw null;
			}
		}

		public bool ShowGroups
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public ImageList? SmallImageList
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool ShowItemToolTips
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public SortOrder Sorting
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public ImageList? StateImageList
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}


		public override string Text
		{
			get
			{
				throw null;
			}
			[param: AllowNull]
			set
			{
				throw null;
			}
		}

		public Size TileSize
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public ListViewItem? TopItem
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool UseCompatibleStateImageBehavior
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public View View
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public int VirtualListSize
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		public bool VirtualMode
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Padding Padding
		{
			get
			{
				throw null;
			}
			set
			{
				throw null;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler? BackgroundImageLayoutChanged
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

						public event EventHandler? RightToLeftLayoutChanged
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler? TextChanged
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

						public event LabelEditEventHandler? AfterLabelEdit
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

						public event LabelEditEventHandler? BeforeLabelEdit
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

						public event CacheVirtualItemsEventHandler? CacheVirtualItems
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

						public event ColumnClickEventHandler? ColumnClick
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

						public event EventHandler<ListViewGroupEventArgs>? GroupTaskLinkClick
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

						public event ColumnReorderedEventHandler? ColumnReordered
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

						public event ColumnWidthChangedEventHandler? ColumnWidthChanged
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event ColumnWidthChangingEventHandler? ColumnWidthChanging
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event DrawListViewColumnHeaderEventHandler? DrawColumnHeader
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event DrawListViewItemEventHandler? DrawItem
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event DrawListViewSubItemEventHandler? DrawSubItem
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event EventHandler? ItemActivate
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}
		public event ItemCheckEventHandler? ItemCheck
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event ItemCheckedEventHandler? ItemChecked
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event ItemDragEventHandler? ItemDrag
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event ListViewItemMouseHoverEventHandler? ItemMouseHover
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event ListViewItemSelectionChangedEventHandler? ItemSelectionChanged
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event EventHandler<ListViewGroupEventArgs>? GroupCollapsedStateChanged
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public new event EventHandler? PaddingChanged
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}


		public new event PaintEventHandler? Paint
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event RetrieveVirtualItemEventHandler? RetrieveVirtualItem
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event SearchForVirtualItemEventHandler? SearchForVirtualItem
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event EventHandler? SelectedIndexChanged
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public event ListViewVirtualItemsSelectionRangeChangedEventHandler? VirtualItemsSelectionRangeChanged
		{
			add
			{
				throw null;
			}
			remove
			{
				throw null;
			}
		}

		public ListView()
		{
			throw null;
		}

		public void ArrangeIcons(ListViewAlignment value)
		{
			throw null;
		}

		public void ArrangeIcons()
		{
			throw null;
		}

		public void AutoResizeColumns(ColumnHeaderAutoResizeStyle headerAutoResize)
		{
			throw null;
		}

		public void AutoResizeColumn(int columnIndex, ColumnHeaderAutoResizeStyle headerAutoResize)
		{
			throw null;
		}

		public void BeginUpdate()
		{
			throw null;
		}

		public void Clear()
		{
			throw null;
		}

		public void EndUpdate()
		{
			throw null;
		}

		public void EnsureVisible(int index)
		{
			throw null;
		}

		public ListViewItem? FindItemWithText(string text)
		{
			throw null;
		}

		public ListViewItem? FindItemWithText(string text, bool includeSubItemsInSearch, int startIndex)
		{
			throw null;
		}

		public ListViewItem? FindItemWithText(string text, bool includeSubItemsInSearch, int startIndex, bool isPrefixSearch)
		{
			throw null;
		}

		public ListViewItem? FindNearestItem(SearchDirectionHint dir, Point point)
		{
			throw null;
		}

		public ListViewItem? FindNearestItem(SearchDirectionHint searchDirection, int x, int y)
		{
			throw null;
		}

		public ListViewItem? GetItemAt(int x, int y)
		{
			throw null;
		}

		public Rectangle GetItemRect(int index)
		{
			throw null;
		}

		public Rectangle GetItemRect(int index, ItemBoundsPortion portion)
		{
			throw null;
		}

		public ListViewHitTestInfo HitTest(Point point)
		{
			throw null;
		}

		public ListViewHitTestInfo HitTest(int x, int y)
		{
			throw null;
		}


		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void RedrawItems(int startIndex, int endIndex, bool invalidateOnly)
		{
			throw null;
		}

		public void Sort()
		{
			throw null;
		}

		public override string ToString()
		{
			throw null;
		}

	}
}
