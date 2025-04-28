using BlazorWebAppMovies.Shared.Grid;

namespace BlazorWebAppMovies.Shared.UnitTests.GridTests.InfoGridTests;

public class InfoGridTestsBaseClass
{
    protected List<string> _columnNames;
    protected List<ColumnType> _columnTypes;
    protected List<Guid> _ids;
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

        _ids = [
            Guid.Parse("09191919-1919-1919-1919-191919191918"),
            Guid.Parse("12323232-3232-3232-3232-323232323230"),
            Guid.Parse("1B4B4B4B-4B4B-4B4B-4B4B-4B4B4B4B4B48"),
            Guid.Parse("24646464-6464-6464-6464-646464646460"),
            Guid.Parse("2D7D7D7D-7D7D-7D7D-7D7D-7D7D7D7D7D78"),
            Guid.Parse("36969696-9696-9696-9696-969696969690"),
            Guid.Parse("3FAFAFAF-AFAF-AFAF-AFAF-AFAFAFAFAFA8"),
            Guid.Parse("48C8C8C8-C8C8-C8C8-C8C8-C8C8C8C8C8C0"),
            Guid.Parse("51E1E1E1-E1E1-E1E1-E1E1-E1E1E1E1E1D8"),
            Guid.Parse("5AFAFAFA-FAFA-FAFA-FAFA-FAFAFAFAFAF0"),
            Guid.Parse("64181818-1818-1818-1818-181818181808"),
            Guid.Parse("6D313131-3131-3131-3131-313131313120"),
            Guid.Parse("764A4A4A-4A4A-4A4A-4A4A-4A4A4A4A4A38"),
            Guid.Parse("7F636363-6363-6363-6363-636363636350"),
            Guid.Parse("887C7C7C-7C7C-7C7C-7C7C-7C7C7C7C7C68"),
            Guid.Parse("91959595-9595-9595-9595-959595959580"),
            Guid.Parse("9AAEAEAE-AEAE-AEAE-AEAE-AEAEAEAEAE98"),
            Guid.Parse("A3C7C7C7-C7C7-C7C7-C7C7-C7C7C7C7C7B0"),
            Guid.Parse("ACE0E0E0-E0E0-E0E0-E0E0-E0E0E0E0E0C8"),
            Guid.Parse("B5FAFAFA-FAFA-FAFA-FAFA-FAFAFAFAFAE0"),
            Guid.Parse("BF131313-1313-1313-1313-1313131313F8"),
            Guid.Parse("C82C2C2C-2C2C-2C2C-2C2C-2C2C2C2C2C10"),
            Guid.Parse("D1454545-4545-4545-4545-454545454528"),
            Guid.Parse("DA5E5E5E-5E5E-5E5E-5E5E-5E5E5E5E5E40"),
            Guid.Parse("E3777777-7777-7777-7777-777777777758"),
            Guid.Parse("EC909090-9090-9090-9090-909090909070"),
            Guid.Parse("F5A9A9A9-A9A9-A9A9-A9A9-A9A9A9A9A988"),
            Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"),
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

        _infoGrid.ColumnNames = _columnNames;
        _infoGrid.ColumnTypes = _columnTypes;
        _infoGrid.Filters = [.. Enumerable.Repeat<string?>(null, _columnNames.Count)];
        _infoGrid.Ids = _ids;
        _infoGrid.Info = _info;
        _infoGrid.RowsPerPage = 10;
        _infoGrid.TotalPages = 3;
        _infoGrid.TotalRows = 28;
    }
}
