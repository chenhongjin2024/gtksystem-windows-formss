﻿using System.Collections;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms.GtkRender;
using Atk;
using GLib;
using Gtk;
using Pango;

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
            this.dataGridView.Columns.Invalidate();
        }

        private void AddGtkStore(params CellValue[] values)
        {
            TreeIter iter = this.dataGridView.Store.AppendNode();
            int columnscount = this.dataGridView.Store.NColumns;
            for (int idx = 0; idx < columnscount; idx++)
            {
                this.dataGridView.Store.SetValue(iter, idx, idx < values.Length ? values[idx] : new CellValue());
            }
        }

        private void AddGtkStore(params DataGridViewRow[] dataGridViewRows)
        {
            foreach (DataGridViewRow row in dataGridViewRows)
            {
                row.DataGridView = dataGridView;
                AddGtkStore(row.Cells.ConvertAll(c =>
                {
                    if (row.DefaultCellStyle != null && row.DefaultCellStyle.BackColor.Name != "0" && row.DefaultCellStyle.BackColor.Name != "")
                        return new CellValue() { Text = Convert.ToString(c.Value), Background = row.DefaultCellStyle.BackColor };
                    else
                        return new CellValue() { Text = Convert.ToString(c.Value) };
                }).ToArray());
            }
            if (this.dataGridView.Store.NColumns < this.dataGridView.TreeView.Columns.Length)
                this.dataGridView.Columns.Invalidate();
        }
        private void InsertGtkStore(int rowIndex, params CellValue[] values)
        {
            TreeIter iter = this.dataGridView.Store.InsertNode(rowIndex);
            int columnscount = this.dataGridView.Store.NColumns;
            for (int idx = 0; idx < columnscount && idx < values.Length; idx++)
            {
                this.dataGridView.Store.SetValue(iter, idx, values[idx]);
            }
        }
        private void InsertGtkStore(int rowIndex, params DataGridViewRow[] dataGridViewRows)
        {
            int idx = rowIndex;
            foreach (DataGridViewRow row in dataGridViewRows)
            {
                InsertGtkStore(idx, row.Cells.ConvertAll(c =>
                {
                    if (row.DefaultCellStyle != null && row.DefaultCellStyle.BackColor.Name != "0")
                        return new CellValue() { Text = Convert.ToString(c.Value), Background = row.DefaultCellStyle.BackColor };
                    else
                        return new CellValue() { Text = Convert.ToString(c.Value) };
                }).ToArray());
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
            dataGridViewRow.Index = items.Count;
            AddGtkStore(dataGridViewRow);
            return items.Add(dataGridViewRow);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int Add(params object[] values)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.Index = items.Count;
            foreach (object o in values)
            {
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = o });
            }
            AddGtkStore(row);
            return items.Add(row);
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int Add(int count)
        {
            for (int i = 0; i < count; i++)
            {
                DataGridViewRow row = new DataGridViewRow() { Index = items.Count };
                AddGtkStore(row);
                items.Add(row);
            }

            return count;
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
            if (((uint)includeFilter & 0xFFFFFF90u) != 0)
            {
                throw new ArgumentException("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter");
            }

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
        public int GetRowsHeight(DataGridViewElementStates includeFilter)
        {
            if (((uint)includeFilter & 0xFFFFFF90u) != 0)
            {
                throw new ArgumentException("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter");
            }

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
        }
        public DataGridViewRow SharedRow(int rowIndex)
        {
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