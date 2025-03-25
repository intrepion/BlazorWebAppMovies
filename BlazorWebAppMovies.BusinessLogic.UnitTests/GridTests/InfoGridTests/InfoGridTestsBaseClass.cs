using BlazorWebAppMovies.BusinessLogic.Grid;

namespace BlazorWebAppMovies.BusinessLogic.UnitTests.GridTests.InfoGridTests;

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
            "Email",
            "Phone Number",
            "User Name",
        ];

        _columnTypes = [
            ColumnType.Normalized,
            ColumnType.Text,
            ColumnType.Normalized,
        ];

        _info =
        [
            [
                "aa@aa.aa",
                "5555555555",
                "Em",
            ],
            [
                "ab@ab.ab",
                "5558675309",
                "ma",
            ],
            [
                "ac@ac.ac",
                "0123456789",
                "ai",
            ],
            [
                "ad@ad.ad",
                "9876543210",
                "il",
            ],
            [
                "ae@ae.ae",
                "5555555555",
                "lN",
            ],
            [
                "af@af.af",
                "5558675309",
                "No",
            ],
            [
                "ag@ag.ag",
                "0123456789",
                "or",
            ],
            [
                "ah@ah.ah",
                "9876543210",
                "rm",
            ],
            [
                "ai@ai.ai",
                "5555555555",
                "al",
            ],
            [
                "aj@aj.aj",
                "5558675309",
                "li",
            ],
            [
                "ak@ak.ak",
                "0123456789",
                "iz",
            ],
            [
                "al@al.al",
                "9876543210",
                "ze",
            ],
            [
                "am@am.am",
                "5555555555",
                "ed",
            ],
            [
                "an@an.an",
                "5558675309",
                "dE",
            ],
            [
                "ao@ao.ao",
                "0123456789",
                "lN",
            ],
            [
                "ap@ap.ap",
                "9876543210",
                "dU",
            ],
            [
                "aq@aq.aq",
                "5555555555",
                "Us",
            ],
            [
                "ar@ar.ar",
                "5558675309",
                "se",
            ],
            [
                "as@as.as",
                "0123456789",
                "er",
            ],
            [
                "at@at.at",
                "9876543210",
                "rN",
            ],
            [
                "au@au.au",
                "5555555555",
                "Na",
            ],
            [
                "av@av.av",
                "5558675309",
                "am",
            ],
            [
                "aw@aw.aw",
                "0123456789",
                "me",
            ],
            [
                "ax@ax.ax",
                "9876543210",
                "eP",
            ],
            [
                "ay@ay.ay",
                "5555555555",
                "Ph",
            ],
            [
                "az@az.az",
                "5558675309",
                "ho",
            ],
            [
                "ba@ba.ba",
                "0123456789",
                "on",
            ],
            [
                "bb@bb.bb",
                "9876543210",
                "ne",
            ],
        ];

        _infoGrid = new InfoGrid();

        _infoGrid.SetInitialInfo(_columnNames, _columnTypes, _info);
    }
}
