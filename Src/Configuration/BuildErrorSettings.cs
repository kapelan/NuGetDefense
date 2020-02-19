namespace NuGetDefense
{
    public class BuildErrorSettings
    {
        internal double _cvss3Threshold = -1;

        public Severity ErrorSeverityThreshold
        {
            get
            {
                if (_cvss3Threshold > 8.9) return Severity.Critical;
                if (_cvss3Threshold > 6.9) return Severity.High;
                if (_cvss3Threshold > 3.9) return Severity.Medium;
                if (_cvss3Threshold > 0) return Severity.Low;
                return _cvss3Threshold < 0 ? Severity.Any : Severity.None;
            }
            set
            {
                _cvss3Threshold = value switch
                {
                    Severity.Any => -1,
                    Severity.None => 0,
                    Severity.Low => 0.1,
                    Severity.Medium => 4.0,
                    Severity.High => 7.0,
                    Severity.Critical => 9.0,
                    _ => _cvss3Threshold
                };
            }
        }

        public double CVSS3Threshold
        {
            get => _cvss3Threshold;
            set => _cvss3Threshold = value;
        }

        /// <summary>
        /// List Package Id and Version/Range to be ignored (https://docs.microsoft.com/en-us/nuget/concepts/package-versioning#version-ranges-and-wildcards)
        /// Version is "any" if omitted
        /// </summary>
        public NuGetPackage[] IgnoredPackages { get; set; } =
        {
            new NuGetPackage
            {
                Id = "NugetDefense"
            }
        };
        
        /// <summary>
        /// List CVE to be ignored (https://docs.microsoft.com/en-us/nuget/concepts/package-versioning#version-ranges-and-wildcards)
        /// </summary>
        public string[] IgnoredCVEs { get; set; } =
        {
        };
        
        /// <summary>
        /// List Package Id and Version/Range to be Whitelisted (https://docs.microsoft.com/en-us/nuget/concepts/package-versioning#version-ranges-and-wildcards)
        /// Version is "any" if omitted
        /// </summary>
        public NuGetPackage[] WhiteListedPackages { get; set; } = {};
        
        /// <summary>
        /// List Package Id and Version/Range to be Blacklisted (https://docs.microsoft.com/en-us/nuget/concepts/package-versioning#version-ranges-and-wildcards)
        /// Version is "any" if omitted
        /// </summary>
        public NuGetPackage[] BlackListedPackages { get; set; } = { };
    }
}