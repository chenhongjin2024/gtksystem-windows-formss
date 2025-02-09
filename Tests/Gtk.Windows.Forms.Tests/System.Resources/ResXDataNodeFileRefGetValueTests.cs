﻿//
// ResXDataNodeFileRefGetValueTests.cs
// 
// Author:
//	Gary Barnett (gary.barnett.mono@gmail.com)
// 
// Copyright (C) Gary Barnett (2012)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.Reflection;
using System.Drawing;
using System.Resources;
using System.ComponentModel.Design;

namespace GtkTests.System.Resources;

[TestFixture]
public class ResXDataNodeFileRefGetValueTests : ResourcesTestHelper
{
    [Test]
    public void ITRSNotUsedWhenNodeFromReader()
    {
        ResXDataNode originalNode, returnedNode;
        originalNode = GetNodeFileRefToSerializable("ser.bbb", true);
        returnedNode = GetNodeFromResXReader(originalNode);

        Assert.IsNotNull(returnedNode, "#A1");
        object val = returnedNode.GetValue(new ReturnSerializableSubClassITRS());
        Assert.True(typeof(serializableSubClass) != val.GetType(), "#A2");
        Assert.True(typeof(serializable) == val.GetType(), "#A3");
    }

    [Test]
    public void CantGetValueWithOnlyFullNameAsType()
    {
        Assert.Throws<TypeLoadException>(() =>
        {
            ResXDataNode originalNode, returnedNode;
            originalNode = GetNodeFileRefToSerializable("ser.bbb", false);
            returnedNode = GetNodeFromResXReader(originalNode);

            Assert.IsNotNull(returnedNode, "#A1");
            object obj = returnedNode.GetValue((AssemblyName[])null);
        });
    }

    [Test]
    public void CantGetValueWithOnlyFullNameAsTypeByProvidingAssemblyName()
    {
        Assert.Throws<TypeLoadException>(() =>
            {
                ResXDataNode originalNode, returnedNode;

                string aName = "System.Windows.Forms_test_net_2_0, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
                AssemblyName[] assemblyNames = new AssemblyName[] { new AssemblyName(aName) };

                originalNode = GetNodeFileRefToSerializable("ser.bbb", false);
                returnedNode = GetNodeFromResXReader(originalNode);

                Assert.IsNotNull(returnedNode, "#A1");
                object obj = returnedNode.GetValue(assemblyNames);
            });
    }

    [Test]
    public void ITRSNotUsedWhenNodeCreatedNew()
    {
        ResXDataNode node;
        node = GetNodeFileRefToSerializable("ser.bbb", true);

        object val = node.GetValue(new ReturnSerializableSubClassITRS());
        Assert.False(typeof(serializableSubClass)== val.GetType(), "#A1");
        Assert.True(typeof(serializable)== val.GetType(), "#A2");
    }

    [Test]
    public void LoadingFileFails()
    {
        Assert.Throws<TargetInvocationException>(() =>
        {
            string corruptFile = Path.GetTempFileName();
            ResXFileRef fileRef = new ResXFileRef(corruptFile, typeof(serializable).AssemblyQualifiedName);

            File.AppendAllText(corruptFile, "corrupt");
            ResXDataNode node = new ResXDataNode("aname", fileRef);
            node.GetValue((AssemblyName[])null);
        });
    }

    #region initial

    [Test]
    public void NullAssemblyNamesOK()
    {
        ResXDataNode node = GetNodeFileRefToIcon();

        Object ico = node.GetValue((AssemblyName[])null);
        Assert.IsNotNull(ico, "#A1");
        Assert.True(typeof(Icon)== ico.GetType(), "#A2");
    }

    [Test]
    public void NullITRSOK()
    {
        ResXDataNode node = GetNodeFileRefToIcon();

        Object ico = node.GetValue((ITypeResolutionService)null);
        Assert.IsNotNull(ico, "#A1");
        Assert.False(typeof(Icon) == ico.GetType(), "#A2");
    }

    [Test]
    public void WrongITRSOK()
    {
        ResXDataNode node = GetNodeFileRefToIcon();

        Object ico = node.GetValue(new DummyITRS());
        Assert.IsNotNull(ico, "#A1");
        Assert.True(typeof(Icon) == ico.GetType(), "#A2");
    }

    [Test]
    public void WrongAssemblyNamesOK()
    {
        ResXDataNode node = GetNodeFileRefToIcon();
        AssemblyName[] ass = new AssemblyName[1];
        ass[0] = new AssemblyName("System.Design");

        Object ico = node.GetValue(ass);
        Assert.IsNotNull(ico, "#A1");
        Assert.False(typeof(Icon) == ico.GetType(), "#A2");
    }

    #endregion

}