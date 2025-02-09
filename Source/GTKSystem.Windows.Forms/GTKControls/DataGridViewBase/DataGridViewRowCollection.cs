﻿/*
 * 基于GTK组件开发，兼容原生C#控件winform界面的跨平台界面组件。
 * 使用本组件GTKSystem.Windows.Forms代替Microsoft.WindowsDesktop.App.WindowsForms，一次编译，跨平台windows、linux、macos运行
 * 技术支持438865652@qq.com，https://www.gtkapp.com, https://gitee.com/easywebfactory, https://github.com/easywebfactory
 * author:chenhongjin
 */
using Gtk;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms.GtkRender;


namespace System.Windows.Forms
{
    [ListBindable(false)]
    public class DataGridViewRowCollection : ICollection, IEnumerable, IList
    {
        private ArrayList items = new ArrayList();
        private DataGridView dataGridView;
        public DataGridViewRowCollection(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        public int Count => items.Count;

        private TreeIter AddGtkStore(List<CellValue> values)
        {
            int columnscount = this.dataGridView.Store.NColumns;
            for (int i = values.Count; i < columnscount; i++)
                values.Add(new CellValue());
            TreeIter iter = this.dataGridView.Store.AppendValues(values.GetRange(0, columnscount).ToArray());
            return iter;
        }
        private TreeIter AddGtkStore(TreeIter parent, List<CellValue> values)
        {
            int columnscount = this.dataGridView.Store.NColumns;
            for (int i = values.Count; i < columnscount; i++)
                values.Add(new CellValue());
            TreeIter iter = this.dataGridView.Store.AppendValues(parent, values.GetRange(0, columnscount).ToArray());
            return iter;
        }
        private void AddGtkStore(params DataGridViewRow[] dataGridViewRows)
        {
            int rowindex = GetRowCount(DataGridViewElementStates.None);
            foreach (DataGridViewRow row in dataGridViewRows)
            {
                row.DataGridView = dataGridView;
                row.Index = rowindex;
                DataGridViewCellStyle _cellStyle = row.DefaultCellStyle;
                if (dataGridView.RowsDefaultCellStyle != null)
                    _cellStyle = dataGridView.RowsDefaultCellStyle;
                if (rowindex % 2 != 0 && dataGridView.AlternatingRowsDefaultCellStyle != null)
                    _cellStyle = dataGridView.AlternatingRowsDefaultCellStyle;

                row.TreeIter = AddGtkStore(row.Cells.ConvertAll(c =>
                {
                    return new CellValue() { Value = c.Value, Style = c.Style ?? _cellStyle };
                }));
                rowindex++;
                foreach (DataGridViewRow child in row.Children)
                {
                    items.Add(child);
                    AddGtkStore(row.TreeIter, ref rowindex, child);
                }
            }
        }
        private void AddGtkStore(TreeIter parent, ref int rowindex, DataGridViewRow row)
        {
            row.Index = rowindex;
            row.DataGridView = dataGridView;
            DataGridViewCellStyle _cellStyle = row.DefaultCellStyle;
            if (dataGridView.RowsDefaultCellStyle != null)
                _cellStyle = dataGridView.RowsDefaultCellStyle;
            if (rowindex % 2 != 0 && dataGridView.AlternatingRowsDefaultCellStyle != null)
                _cellStyle = dataGridView.AlternatingRowsDefaultCellStyle;

            row.TreeIter = AddGtkStore(parent, row.Cells.ConvertAll(c =>
            {
                return new CellValue() { Value = c.Value, Style = c.Style ?? _cellStyle };
            }));
            rowindex++;
            foreach (DataGridViewRow child in row.Children)
            {
                items.Add(child);
                AddGtkStore(row.TreeIter, ref rowindex, child);
            }

        }
        private TreeIter InsertGtkStore(int rowIndex, List<CellValue> values)
        {
            int columnscount = this.dataGridView.Store.NColumns;
            for (int i = values.Count; i < columnscount; i++)
                values.Add(new CellValue());
            TreeIter iter = this.dataGridView.Store.InsertWithValues(rowIndex, values.GetRange(0, columnscount).ToArray());
            return iter;
        }
        private void InsertGtkStore(int rowIndex, params DataGridViewRow[] dataGridViewRows)
        {
            int idx = rowIndex;
            foreach (DataGridViewRow row in dataGridViewRows)
            {
                int rowindex = GetRowCount(DataGridViewElementStates.None);
                DataGridViewCellStyle _cellStyle = row.DefaultCellStyle;
                if (dataGridView.RowsDefaultCellStyle != null)
                    _cellStyle = dataGridView.RowsDefaultCellStyle;
                if (rowindex % 2 != 0 && dataGridView.AlternatingRowsDefaultCellStyle != null)
                    _cellStyle = dataGridView.AlternatingRowsDefaultCellStyle;

                row.TreeIter = InsertGtkStore(idx, row.Cells.ConvertAll(c =>
                {
                    return new CellValue() { Value = c.Value, Style = c.Style ?? _cellStyle };
                }));
                idx++;
            }
        }
        public DataGridViewRow this[int index]
        {
            get
            {
                DataGridViewRow dataGridViewRow = SharedRow(index);
                return dataGridViewRow;
            }
        }
        protected DataGridView DataGridView { get { return dataGridView; } }
        internal ArrayList SharedList => items;
        protected ArrayList List { get { return items; } }

        bool IList.IsFixedSize => false;

        bool IList.IsReadOnly => false;

        int ICollection.Count => items.Count;

        bool ICollection.IsSynchronized => false;

        object ICollection.SyncRoot => this;

        object IList.this[int index] { get => items[index]; set => throw new NotSupportedException(); }
        
        public event CollectionChangeEventHandler CollectionChanged;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int Add()
        {
            DataGridViewRow row = new DataGridViewRow() { Index = items.Count };
            AddGtkStore(row);
            items.Add(row);
            return 1;
        }
        public virtual int Add(DataGridViewRow dataGridViewRow)
        {
            AddGtkStore(dataGridViewRow);
            return items.Add(dataGridViewRow);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int Add(params object[] values)
        {
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.Index = items.Count;
            var cols = dataGridView.Columns;
            int colleng = Math.Min(values.Length, cols.Count);
            for (int i = 0; i < colleng; i++)
            {
                object cellvalue = values[i];
                var col = cols[i];
                if (col is DataGridViewTextBoxColumn)
                    newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = cellvalue });
                else if (col is DataGridViewImageColumn)
                    newRow.Cells.Add(new DataGridViewImageCell() { Value = cellvalue });
                else if (col is DataGridViewCheckBoxColumn)
                    newRow.Cells.Add(new DataGridViewCheckBoxCell() { Value = cellvalue });
                else if (col is DataGridViewButtonColumn)
                    newRow.Cells.Add(new DataGridViewButtonCell() { Value = cellvalue });
                else if (col is DataGridViewComboBoxColumn)
                    newRow.Cells.Add(new DataGridViewComboBoxCell() { Value = cellvalue });
                else if (col is DataGridViewLinkColumn)
                    newRow.Cells.Add(new DataGridViewLinkCell() { Value = cellvalue });
                else
                    newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = cellvalue });
            }
            return Add(newRow);
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int Add(int count)
        {
            int start = items.Count;
            for (int i = 0; i < count; i++)
            {
                DataGridViewRow row = new DataGridViewRow() { Index = start + i };
                AddGtkStore(row);
                items.Add(row);
            }

            return start + count;
        }
        public virtual int AddCopies(int indexSource, int count)
        {
            DataGridViewRow[] arr = new DataGridViewRow[count];
            items.CopyTo(0, arr, indexSource, count);
            this.AddRange(arr);
            return count;
        }
        public virtual int AddCopy(int indexSource)
        {
            return AddCopies(indexSource, 1);
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual void AddRange(params DataGridViewRow[] dataGridViewRows)
        {
            if (this.dataGridView.Store.NColumns < this.dataGridView.GridView.Columns.Length)
                this.dataGridView.Columns.Invalidate();

            AddGtkStore(dataGridViewRows);
            items.AddRange(dataGridViewRows);
        }
        public virtual void Clear()
        {
            dataGridView.Store.Clear();
            items.Clear();
        }
        public virtual bool Contains(DataGridViewRow dataGridViewRow)
        {
            return items.IndexOf(dataGridViewRow) != -1;
        }
        public void CopyTo(DataGridViewRow[] array, int index)
        {
            items.CopyTo(array, index);
        }
        public int GetFirstRow(DataGridViewElementStates includeFilter)
        {
            int idx = -1;
            for (int i = 0; i < items.Count; i++)
            {
                if (((DataGridViewRow)items[i]).State == includeFilter)
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }

        public int GetFirstRow(DataGridViewElementStates includeFilter, DataGridViewElementStates excludeFilter)
        {
            int idx = -1;
            for (int i = 0; i < items.Count; i++)
            {
                if (((DataGridViewRow)items[i]).State == includeFilter || ((DataGridViewRow)items[i]).State == excludeFilter)
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }
        public int GetLastRow(DataGridViewElementStates includeFilter)
        {
            int idx = -1;
            for (int i = 0; i < items.Count; i++)
            {
                if (((DataGridViewRow)items[i]).State == includeFilter)
                {
                    idx = i;
                }
            }
            return idx;
        }
        public int GetNextRow(int indexStart, DataGridViewElementStates includeFilter)
        {
            int idx = -1;
            for (int i = indexStart - 1; i < items.Count; i++)
            {
                if (((DataGridViewRow)items[i]).State == includeFilter)
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }
        public int GetNextRow(int indexStart, DataGridViewElementStates includeFilter, DataGridViewElementStates excludeFilter)
        {
            int idx = -1;
            for (int i = indexStart - 1; i < items.Count; i++)
            {
                if (((DataGridViewRow)items[i]).State == includeFilter || ((DataGridViewRow)items[i]).State == excludeFilter)
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }
        public int GetPreviousRow(int indexStart, DataGridViewElementStates includeFilter, DataGridViewElementStates excludeFilter)
        {
            int idx = -1;
            for (int i = indexStart - 1; i > -1; i--)
            {
                if (((DataGridViewRow)items[i]).State == includeFilter || ((DataGridViewRow)items[i]).State == excludeFilter)
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }
        public int GetPreviousRow(int indexStart, DataGridViewElementStates includeFilter)
        {
            int idx = -1;
            for (int i = indexStart-1; i > -1; i--)
            {
                if (((DataGridViewRow)items[i]).State == includeFilter)
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }
        public int GetRowCount(DataGridViewElementStates includeFilter)
        {
            //if (((uint)includeFilter & 0xFFFFFF90u) != 0)
            //{
            //    throw new ArgumentException("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter");
            //}
            if (includeFilter == DataGridViewElementStates.None)
                return items.Count;
            else
            {
                int num = 0;
                for (int i = 0; i < items.Count; i++)
                {
                    if ((GetRowState(i) & includeFilter) == includeFilter)
                    {
                        num++;
                    }
                }
                return num;
            }
        }
        public int GetRowsHeight(DataGridViewElementStates includeFilter)
        {
            //if (((uint)includeFilter & 0xFFFFFF90u) != 0)
            //{
            //    throw new ArgumentException("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter");
            //}
            int num = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if ((GetRowState(i) & includeFilter) == includeFilter)
                {
                    num += ((DataGridViewRow)items[i]).GetHeight(i);
                }
            }
            return num;
        }
        public virtual DataGridViewElementStates GetRowState(int rowIndex)
        {
            return ((DataGridViewRow)items[rowIndex]).State;
        }
        public int IndexOf(DataGridViewRow dataGridViewRow)
        {
            return items.IndexOf(dataGridViewRow);
        }
        public virtual void Insert(int rowIndex, params object[] values)
        {
            DataGridViewRow row = new DataGridViewRow();
            foreach (object o in values)
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = o });
            InsertGtkStore(rowIndex, row);
            items.Insert(rowIndex, row);
        }
        public virtual void Insert(int rowIndex, DataGridViewRow dataGridViewRow)
        {
            InsertGtkStore(rowIndex, dataGridViewRow);
            items.Insert(rowIndex, dataGridViewRow);
        }

        public virtual void Insert(int rowIndex, int count) {
            DataGridViewRow row = new DataGridViewRow();
            for (int i=0;i < DataGridView.Columns.Count;i++)
                row.Cells.Add(new DataGridViewTextBoxCell());
            InsertGtkStore(rowIndex, row);
            items.Insert(rowIndex, row);
        }

        public virtual void InsertCopies(int indexSource, int indexDestination, int count) { }

        public virtual void InsertCopy(int indexSource, int indexDestination) { }
        public virtual void InsertRange(int rowIndex, params DataGridViewRow[] dataGridViewRows)
        {
            int i = rowIndex;
            foreach (DataGridViewRow row in dataGridViewRows)
            {
                items.Insert(i, row);
                i++;
            }
            InsertGtkStore(rowIndex, dataGridViewRows);
        }
        public virtual void Remove(DataGridViewRow dataGridViewRow) {
            RemoveAt(dataGridViewRow.Index);
        }
        public virtual void RemoveAt(int index) {
            if (dataGridView.Store.GetIter(out TreeIter iter, new TreePath(new int[] { index })))
            {
                dataGridView.Store.Remove(ref iter);
            }
            items.RemoveAt(index);
            //reset id
            for (int i = 0; i < items.Count; i++)
            {
                ((DataGridViewRow)items[i]).Index = i;
            }
        }
        public DataGridViewRow SharedRow(int rowIndex)
        {
            bool hasiter = dataGridView.Store.GetIter(out TreeIter iter,new TreePath(new int[] { rowIndex }));
            if (hasiter)
            {
                foreach (DataGridViewRow item in items)
                {
                    if(item.TreeIter.Equals(iter.UserData))
                        return item;
                }
            }
            return (DataGridViewRow)SharedList[rowIndex];
        }
        //**************************************
        protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
        {
            if (CollectionChanged != null)
                CollectionChanged(dataGridView, e);
        }

        int IList.Add(object value)
        {
            return Add((DataGridViewRow)value);
        }

        void IList.Clear()
        {
            Clear();
        }

        bool IList.Contains(object value)
        {
            return items.Contains(value);
        }

        int IList.IndexOf(object value)
        {
            return items.IndexOf(value);
        }

        void IList.Insert(int index, object value)
        {
            Insert(index, (DataGridViewRow)value);
        }

        void IList.Remove(object value)
        {
            Remove((DataGridViewRow)value);
        }

        void IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        void ICollection.CopyTo(Array array, int index)
        {
            items.CopyTo(array, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

    }
}