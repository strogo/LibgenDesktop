﻿using System;
using System.Collections.Generic;

namespace LibgenDesktop.Models.Localization.Localizators
{
    internal class LibraryWindowLocalizator : Localizator
    {
        public LibraryWindowLocalizator(List<Translation> prioritizedTranslationList, LanguageFormatter formatter)
            : base(prioritizedTranslationList, formatter)
        {
            WindowTitle = Format(translation => translation?.WindowTitle);
            Scan = Format(translation => translation?.Scan);
            BrowseDirectoryDialogTitle = Format(translation => translation?.BrowseDirectoryDialogTitle);
            CreatingIndexes = Format(translation => translation?.CreatingIndexes);
            ScanLog = Format(translation => translation?.ScanLog);
            Error = Format(translation => translation?.Error);
            ColumnsFile = Format(translation => translation?.File);
            ColumnsAuthors = Format(translation => translation?.Authors);
            ColumnsTitle = Format(translation => translation?.Title);
        }

        public string WindowTitle { get; }
        public string Scan { get; }
        public string BrowseDirectoryDialogTitle { get; }
        public string CreatingIndexes { get; }
        public string ScanLog { get; }
        public string Error { get; }
        public string ColumnsFile { get; }
        public string ColumnsAuthors { get; }
        public string ColumnsTitle { get; }

        public string GetScanStartedString(string directory) => Format(translation => translation?.ScanStarted, new { directory });
        public string GetFoundString(int count) => Format(translation => translation?.Found, new { count });
        public string GetNotFoundString(int count) => Format(translation => translation?.NotFound, new { count });
        public string GetScanCompleteString(int found, int notFound, int errors) => Format(translation => translation?.ScanComplete,
            new { found = Formatter.ToFormattedString(found), notFound = Formatter.ToFormattedString(notFound),
                errors = Formatter.ToFormattedString(errors) });

        private string Format(Func<Translation.LibraryTranslation, string> field, object templateArguments = null)
        {
            return Format(translation => field(translation?.Library), templateArguments);
        }

        private string Format(Func<Translation.LibraryColumnsTranslation, string> field, object templateArguments = null)
        {
            return Format(translation => field(translation?.Library?.Columns), templateArguments);
        }
    }
}
