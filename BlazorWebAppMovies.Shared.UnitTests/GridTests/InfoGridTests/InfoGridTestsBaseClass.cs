using BlazorWebAppMovies.Shared.Grid;

namespace BlazorWebAppMovies.Shared.UnitTests.GridTests.InfoGridTests;

public class InfoGridTestsBaseClass
{
    protected List<string> _columnNames;
    protected List<ColumnType> _columnTypes;
    protected List<List<string>> _info;
    protected InfoGrid _infoGrid;

    [SetUp]
    public void Setup()
    {
        _columnNames = [
            "Completed Date and Time",
            "Is Completed",
            "Ordering",
            "Title",
            "To Do List",
        ];

        _columnTypes = [
            ColumnType.DateTime,
            ColumnType.Boolean,
            ColumnType.Integer,
            ColumnType.Normalized,
            ColumnType.Normalized,
        ];

        _info = [
            [
                "2 days ago",
                "True",
                "1",
                "Replace kitchen sponge",
                "Shopping & Supplies",
            ],
            [
                "1 hour ago",
                "True",
                "1",
                "Go for a 30-minute walk",
                "Personal & Wellness",
            ],
            [
                "",
                "False",
                "2",
                "Read 1 chapter of 'Atomic Habits'",
                "Personal & Wellness",
            ],
            [
                "1 day ago",
                "True",
                "1",
                "Send project update email",
                "Work & Projects",
            ],
            [
                "",
                "False",
                "2",
                "Review presentation slides",
                "Work & Projects",
            ],
            [
                "5 hours ago",
                "True",
                "3",
                "Schedule team meeting",
                "Work & Projects",
            ],
            [
                "",
                "False",
                "4",
                "Complete expense report",
                "Work & Projects",
            ],
            [
                "6 days ago",
                "True",
                "1",
                "Pay electric bill",
                "Finances & Bills",
            ],
            [
                "",
                "False",
                "2",
                "Pay internet bill",
                "Finances & Bills",
            ],
            [
                "3 days ago",
                "True",
                "3",
                "Transfer money to savings",
                "Finances & Bills",
            ],
            [
                "",
                "False",
                "4",
                "Review credit card statement",
                "Finances & Bills",
            ],
            [
                "1 day ago",
                "True",
                "5",
                "Update budget spreadsheet",
                "Finances & Bills",
            ],
            [
                "",
                "False",
                "6",
                "Research investment options",
                "Finances & Bills",
            ],
            [
                "2 hours ago",
                "True",
                "7",
                "Cancel unused subscription",
                "Finances & Bills",
            ],
            [
                "2 days ago",
                "True",
                "1",
                "Pick up dry cleaning",
                "Social & Errands",
            ],
            [
                "",
                "False",
                "2",
                "Return library books",
                "Social & Errands",
            ],
            [
                "4 days ago",
                "True",
                "3",
                "Mail birthday card",
                "Social & Errands",
            ],
            [
                "",
                "False",
                "4",
                "Call doctor's office",
                "Social & Errands",
            ],
            [
                "1 day ago",
                "True",
                "5",
                "Buy stamps",
                "Social & Errands",
            ],
            [
                "",
                "False",
                "6",
                "Schedule hair appointment",
                "Social & Errands",
            ],
            [
                "8 hours ago",
                "True",
                "7",
                "Get car washed",
                "Social & Errands",
            ],
            [
                "",
                "False",
                "8",
                "Visit post office",
                "Social & Errands",
            ],
            [
                "3 hours ago",
                "True",
                "9",
                "Buy groceries",
                "Social & Errands",
            ],
            [
                "",
                "False",
                "10",
                "Pick up prescription",
                "Social & Errands",
            ],
            [
                "5 days ago",
                "True",
                "11",
                "Drop off donations",
                "Social & Errands",
            ],
            [
                "",
                "False",
                "12",
                "Get oil changed",
                "Social & Errands",
            ],
            [
                "1 day ago",
                "True",
                "13",
                "Plan weekend dinner",
                "Social & Errands",
            ],
            [
                "",
                "False",
                "14",
                "RSVP for party",
                "Social & Errands",
            ],
        ];

        _infoGrid = new InfoGrid();

        _infoGrid.SetInitialInfo(_columnNames, _columnTypes, _info);
    }
}
