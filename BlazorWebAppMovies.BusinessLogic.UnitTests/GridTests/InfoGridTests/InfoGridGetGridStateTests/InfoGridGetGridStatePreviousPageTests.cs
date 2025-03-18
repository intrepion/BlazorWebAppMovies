using BlazorWebAppMovies.BusinessLogic.Entities;
using BlazorWebAppMovies.BusinessLogic.Grid;

namespace BlazorWebAppMovies.BusinessLogic.UnitTests.GridTests.InfoGridTests.InfoGridGetGridStateTests;

public class InfoGridGetGridStatePreviousPageTests
{
    private List<ApplicationUser> _listApplicationUser;
    private InfoGrid<ApplicationUser> _infoGridApplicationUser;

    [SetUp]
    public void Setup()
    {
        _listApplicationUser =
        [
            new()
            {
                Email = "aa@aa.aa",
                NormalizedEmail = "AA@AA.AA",
                NormalizedUserName = "EM",
                PhoneNumber = "5555555555",
                UserName = "Em",
            },
            new()
            {
                Email = "ab@ab.ab",
                NormalizedEmail = "AB@AB.AB",
                NormalizedUserName = "MA",
                PhoneNumber = "5558675309",
                UserName = "ma",
            },
            new()
            {
                Email = "ac@ac.ac",
                NormalizedEmail = "AC@AC.AC",
                NormalizedUserName = "AI",
                PhoneNumber = "0123456789",
                UserName = "ai",
            },
            new()
            {
                Email = "ad@ad.ad",
                NormalizedEmail = "AD@AD.AD",
                NormalizedUserName = "IL",
                PhoneNumber = "9876543210",
                UserName = "il",
            },
            new()
            {
                Email = "ae@ae.ae",
                NormalizedEmail = "AE@AE.AE",
                NormalizedUserName = "LN",
                PhoneNumber = "5555555555",
                UserName = "lN",
            },
            new()
            {
                Email = "af@af.af",
                NormalizedEmail = "AF@AF.AF",
                NormalizedUserName = "NO",
                PhoneNumber = "5558675309",
                UserName = "No",
            },
            new()
            {
                Email = "ag@ag.ag",
                NormalizedEmail = "AG@AG.AG",
                NormalizedUserName = "OR",
                PhoneNumber = "0123456789",
                UserName = "or",
            },
            new()
            {
                Email = "ah@ah.ah",
                NormalizedEmail = "AH@AH.AH",
                NormalizedUserName = "RM",
                PhoneNumber = "9876543210",
                UserName = "rm",
            },
            new()
            {
                Email = "ai@ai.ai",
                NormalizedEmail = "AI@AI.AI",
                NormalizedUserName = "AL",
                PhoneNumber = "5555555555",
                UserName = "al",
            },
            new()
            {
                Email = "aj@aj.aj",
                NormalizedEmail = "AJ@AJ.AJ",
                NormalizedUserName = "LI",
                PhoneNumber = "5558675309",
                UserName = "li",
            },
            new()
            {
                Email = "ak@ak.ak",
                NormalizedEmail = "AK@AK.AK",
                NormalizedUserName = "IZ",
                PhoneNumber = "0123456789",
                UserName = "iz",
            },
            new()
            {
                Email = "al@al.al",
                NormalizedEmail = "AL@AL.AL",
                NormalizedUserName = "ZE",
                PhoneNumber = "9876543210",
                UserName = "ze",
            },
            new()
            {
                Email = "am@am.am",
                NormalizedEmail = "AM@AM.AM",
                NormalizedUserName = "ED",
                PhoneNumber = "5555555555",
                UserName = "ed",
            },
            new()
            {
                Email = "an@an.an",
                NormalizedEmail = "AN@AN.AN",
                NormalizedUserName = "DE",
                PhoneNumber = "5558675309",
                UserName = "dE",
            },
            new()
            {
                Email = "ao@ao.ao",
                NormalizedEmail = "AO@AO.AO",
                NormalizedUserName = "LN",
                PhoneNumber = "0123456789",
                UserName = "lN",
            },
            new()
            {
                Email = "ap@ap.ap",
                NormalizedEmail = "AP@AP.AP",
                NormalizedUserName = "DU",
                PhoneNumber = "9876543210",
                UserName = "dU",
            },
            new()
            {
                Email = "aq@aq.aq",
                NormalizedEmail = "AQ@AQ.AQ",
                NormalizedUserName = "US",
                PhoneNumber = "5555555555",
                UserName = "Us",
            },
            new()
            {
                Email = "ar@ar.ar",
                NormalizedEmail = "AR@AR.AR",
                NormalizedUserName = "SE",
                PhoneNumber = "5558675309",
                UserName = "se",
            },
            new()
            {
                Email = "as@as.as",
                NormalizedEmail = "AS@AS.AS",
                NormalizedUserName = "ER",
                PhoneNumber = "0123456789",
                UserName = "er",
            },
            new()
            {
                Email = "at@at.at",
                NormalizedEmail = "AT@AT.AT",
                NormalizedUserName = "RN",
                PhoneNumber = "9876543210",
                UserName = "rN",
            },
            new()
            {
                Email = "au@au.au",
                NormalizedEmail = "AU@AU.AU",
                NormalizedUserName = "NA",
                PhoneNumber = "5555555555",
                UserName = "Na",
            },
            new()
            {
                Email = "av@av.av",
                NormalizedEmail = "AV@AV.AV",
                NormalizedUserName = "AM",
                PhoneNumber = "5558675309",
                UserName = "am",
            },
            new()
            {
                Email = "aw@aw.aw",
                NormalizedEmail = "AW@AW.AW",
                NormalizedUserName = "ME",
                PhoneNumber = "0123456789",
                UserName = "me",
            },
            new()
            {
                Email = "ax@ax.ax",
                NormalizedEmail = "AX@AX.AX",
                NormalizedUserName = "EP",
                PhoneNumber = "9876543210",
                UserName = "eP",
            },
            new()
            {
                Email = "ay@ay.ay",
                NormalizedEmail = "AY@AY.AY",
                NormalizedUserName = "PH",
                PhoneNumber = "5555555555",
                UserName = "Ph",
            },
            new()
            {
                Email = "az@az.az",
                NormalizedEmail = "AZ@AZ.AZ",
                NormalizedUserName = "HO",
                PhoneNumber = "5558675309",
                UserName = "ho",
            },
            new()
            {
                Email = "ba@ba.ba",
                NormalizedEmail = "BA@BA.BA",
                NormalizedUserName = "ON",
                PhoneNumber = "0123456789",
                UserName = "on",
            },
            new()
            {
                Email = "bb@bb.bb",
                NormalizedEmail = "BB@BB.BB",
                NormalizedUserName = "NE",
                PhoneNumber = "9876543210",
                UserName = "ne",
            },
        ];

        _infoGridApplicationUser = new InfoGrid<ApplicationUser>();

        _infoGridApplicationUser.SetInitialInfo(_listApplicationUser);
    }

    [Test]
    public void Page1_WhenPreviousPage()
    {
        var expected = new InfoGridState
        {
            _columns = 3,
            _filters = [],
            _page = 1,
            _rowsPerPage = 10,
            _sorts = [],
            _totalPages = 3,
            _totalRows = 28,
        };

        _infoGridApplicationUser.PreviousPage();
        var actual = _infoGridApplicationUser._infoGridState;

        Assert.Multiple(() =>
        {
            Assert.That(actual._columns, Is.EqualTo(expected._columns), $"Columns is {actual._columns}, but should be {expected._columns}");
            Assert.That(actual._filters, Is.EqualTo(expected._filters), $"Filters is {actual._filters}, but should be {expected._filters}");
            Assert.That(actual._page, Is.EqualTo(expected._page), $"Page is {actual._page}, but should be {expected._page}");
            Assert.That(actual._rowsPerPage, Is.EqualTo(expected._rowsPerPage), $"Rows Per Page is {actual._rowsPerPage}, but should be {expected._rowsPerPage}");
            Assert.That(actual._sorts, Is.EqualTo(expected._sorts), $"Sorts is {actual._sorts}, but should be {expected._sorts}");
            Assert.That(actual._totalPages, Is.EqualTo(expected._totalPages), $"Total Pages is {actual._totalPages}, but should be {expected._totalPages}");
            Assert.That(actual._totalRows, Is.EqualTo(expected._totalRows), $"Total Rows is {actual._totalRows}, but should be {expected._totalRows}");
        });
    }
}
