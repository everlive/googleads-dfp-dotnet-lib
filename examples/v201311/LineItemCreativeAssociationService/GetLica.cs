// Copyright 2013, Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Author: api.anash@gmail.com (Anash P. Oommen)

using Google.Api.Ads.Dfp.Lib;
using Google.Api.Ads.Dfp.v201311;

using System;

namespace Google.Api.Ads.Dfp.Examples.v201311 {
  /// <summary>
  /// This code example gets a line item creative association (LICA) by the line
  /// item and creative ID. To determine which line items exist, run
  /// GetAllLineItems.cs. To determine which creatives exit, run
  /// GetAllCreatives.cs.
  ///
  /// Tags: LineItemCreativeAssociationService.getLineItemCreativeAssociation
  /// </summary>
  class GetLica : SampleBase {
    /// <summary>
    /// Returns a description about the code example.
    /// </summary>
    public override string Description {
      get {
        return "This code example gets a line item creative association (LICA) by the line " +
            "item and creative ID. To determine which line items exist, run " +
            "GetAllLineItems.cs. To determine which creatives exit, run " +
            "GetAllCreatives.cs.";
      }
    }

    /// <summary>
    /// Main method, to run this code example as a standalone application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void Main(string[] args) {
      new GetLica().Run(new DfpUser());
    }

    /// <summary>
    /// Run the code example.
    /// </summary>
    /// <param name="user">The DFP user object running the code example.</param>
    public override void Run(DfpUser user) {
      // Get the LineItemCreativeAssociationService.
      LineItemCreativeAssociationService licaService = (LineItemCreativeAssociationService)
          user.GetService(DfpService.v201311.LineItemCreativeAssociationService);

      // Set the line item and creative ID to use to retrieve the LICA.
      long lineItemId = long.Parse(_T("INSERT_LINE_ITEM_ID_HERE"));
      long creativeId = long.Parse(_T("INSERT_CREATIVE_ID_HERE"));

      try {
        // Get the LICA.
        LineItemCreativeAssociation lica =
            licaService.getLineItemCreativeAssociation(lineItemId, creativeId);

        if (lica != null) {
          Console.WriteLine("LICA with line item ID = {0}, creative ID = '{1}' and status = " +
              "'{2}' was found", lica.lineItemId, lica.creativeId, lica.status);
        } else {
          Console.WriteLine("No LICA found for this ID.");
        }
      } catch (Exception ex) {
        Console.WriteLine("Failed to get LICA. Exception says \"{0}\"", ex.Message);
      }
    }
  }
}
