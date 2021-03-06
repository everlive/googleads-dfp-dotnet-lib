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
using Google.Api.Ads.Dfp.v201306;

using System;

namespace Google.Api.Ads.Dfp.Examples.v201306 {
  /// <summary>
  /// This code example gets all placements. To create placements, run
  /// CreatePlacements.cs.
  ///
  /// Tags: PlacementService.getPlacementsByStatement
  /// </summary>
  class GetAllPlacements : SampleBase {
    /// <summary>
    /// Returns a description about the code example.
    /// </summary>
    public override string Description {
      get {
        return "This code example gets all placements. To create placements, run " +
            "CreatePlacements.cs.";
      }
    }

    /// <summary>
    /// Main method, to run this code example as a standalone application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void Main(string[] args) {
      SampleBase codeExample = new GetAllPlacements();
      Console.WriteLine(codeExample.Description);
      codeExample.Run(new DfpUser());
    }

    /// <summary>
    /// Run the code example.
    /// </summary>
    /// <param name="user">The DFP user object running the code example.</param>
    public override void Run(DfpUser user) {
      // Get the PlacementService.
      PlacementService placementService =
          (PlacementService) user.GetService(DfpService.v201306.PlacementService);

      // Sets defaults for page and Statement.
      PlacementPage page = new PlacementPage();
      Statement statement = new Statement();
      int offset = 0;

      try {
        do {
          // Create a Statement to get all ad units.
          statement.query = string.Format("LIMIT 500 OFFSET {0}", offset);

          // Get ad units by Statement.
          page = placementService.getPlacementsByStatement(statement);

          if (page.results != null && page.results.Length > 0) {
            int i = page.startIndex;
            foreach (Placement placement in page.results) {
              Console.WriteLine("{0}) Placement with ID = '{1}' and name = '{2}' was found.",
                  i, placement.id, placement.name);
              i++;
            }
          }

          offset += 500;
        } while (offset < page.totalResultSetSize);

        Console.WriteLine("Number of results found: {0}" + page.totalResultSetSize);
      } catch (Exception ex) {
        Console.WriteLine("Failed to get all placements. Exception says \"{0}\"",
            ex.Message);
      }
    }
  }
}
