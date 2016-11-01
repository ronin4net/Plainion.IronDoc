﻿namespace Plainion.IronDoc.Tests

open System
open System.IO
open System.Collections.Generic
open NUnit.Framework
open Plainion.IronDoc
open Plainion.IronDoc.Tests.Fakes
open Plainion.IronDoc.Tests.Fakes

type internal OverwrittenMethods() =
    /// <summary>
    /// Returns nicely formatted message about the state of this object
    /// </summary>
    override this.ToString() =
        "silence"

// test specific scenarios - parsing + rendering
[<TestFixture>]
module ParsingTests =
    open Plainion.IronDoc.Parsing
    
    [<Test>]
    let ``Overwritten method is rendered``() =
        let markdownDocument = renderApiDoc typedefof<OverwrittenMethods>

        Assert.That( markdownDocument, Does.Contain """### System.String ToString()

Returns nicely formatted message about the state of this object""" )

    [<Test>]
    let ``Nested type summary is rendered``() =
        let markdownDocument = renderApiDoc typedefof<Scenarios.NestingType>

        Assert.That( markdownDocument, Does.Contain """## Nested types

### Plainion.IronDoc.Tests.Fakes.Scenarios.NestingType.Nested

I am nested""" )
