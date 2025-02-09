//
// ResXDataNodeByteArrayTests.cs : Tests how ResXDataNode handles byte[]
// type resources.
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

using System.Resources;
using System.ComponentModel.Design;
using GtkTests.TypeResolutionService_;
using GtkTests.Internals.Resources;

namespace GtkTests.System.Resources;

[TestFixture]
public class ResXDataNodeByteArrayTests : ResourcesTestHelper {
		
    [Test]
    public void GetValueITRSNotUsedWhenNodeReturnedFromReader ()
    {
        ResXDataNode originalNode, returnedNode;
        originalNode = GetNodeEmdeddedBytes1To10 ();
        returnedNode = GetNodeFromResXReader (originalNode);

        Assert.IsNotNull (returnedNode, "#A1");
        var val = returnedNode.GetValue (new ReturnIntITRS ());
        Assert.True (typeof (byte[])== val.GetType(), "#A2");
    }

    [Test]
    public void GetValueITRSNotTouchedWhenNodeCreatedNew ()
    {
        ResXDataNode node;
        node = GetNodeEmdeddedBytes1To10 ();

        //would raise exception if param used
        var obj = node.GetValue (new ExceptionalITRS ());
        Assert.True (typeof(byte[]) == obj.GetType(), "#A1");
    }

    [Test]
    public void GetValueTypeNameITRSIsUsedWithNodeFromReader ()
    {
        ResXDataNode originalNode, returnedNode;
        originalNode = GetNodeEmdeddedBytes1To10 ();
        returnedNode = GetNodeFromResXReader (originalNode);

        Assert.IsNotNull (returnedNode, "#A1");
        var returnedType = returnedNode.GetValueTypeName (new ReturnIntITRS ());
        Assert.AreEqual ((typeof (int)).AssemblyQualifiedName, returnedType, "#A2");
    }

    [Test]
    public void GetValueTypeNameITRSIsUsedAfterGetValueCalledWithNodeFromReader ()
    {
        ResXDataNode originalNode, returnedNode;
        originalNode = GetNodeEmdeddedBytes1To10 ();
        returnedNode = GetNodeFromResXReader (originalNode);

        Assert.IsNotNull (returnedNode, "#A1");
        var obj = returnedNode.GetValue ((ITypeResolutionService) null);
        var returnedType = returnedNode.GetValueTypeName (new ReturnIntITRS ());
        Assert.AreEqual ((typeof (int)).AssemblyQualifiedName, returnedType, "#A2");
    }

    [Test]
    public void GetValueTypeNameITRSNotUsedWhenNodeCreatedNew ()
    {
        ResXDataNode node;
        node = GetNodeEmdeddedBytes1To10 ();

        var returnedType = node.GetValueTypeName (new ReturnIntITRS ());
        Assert.AreEqual ((typeof (byte[])).AssemblyQualifiedName, returnedType, "#A1");
    }
}