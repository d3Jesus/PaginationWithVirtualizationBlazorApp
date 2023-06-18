using System.ComponentModel.DataAnnotations;

namespace PaginationWithVirtualizationBlazorApp.Data;

//
// Summary:
//     Simple pagination structure
// Parameters:
//   Text:
//     The text showed to the user. Eg: Prev, 1, 2, 3, Next.
//   PageIndex:
//     The page number value used to define the data to display corresponding that page.
//   IsEnabled:
//     Adds the 'disabled' CSS class if the index ou page number is selected.
//   IsActive:
//     Adds the 'active' CSS class if the index ou page number is selected.
//
// Returns:
//     true if validation is successful; otherwise, false.
//
public record struct PageItem(string Text, int PageIndex, bool IsEnabled, bool IsActive);
