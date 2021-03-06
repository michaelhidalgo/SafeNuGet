﻿using Owasp.SafeNuGet.NuGet;
using Owasp.SafeNuGet.Unsafe;
using System.Collections.Generic;
using System.Linq;

namespace Owasp.SafeNuGet
{
    public class DecisionMaker
    {
        public List<KeyValuePair<NuGetPackage, UnsafePackage>> Evaluate(NuGetPackages packages, UnsafePackages unsafePackages) 
        {
            var result = new List<KeyValuePair<NuGetPackage, UnsafePackage>>();
            foreach(var package in packages) 
            {
                foreach(var unsafePackage in unsafePackages.Where(u => u.Is(package))) 
                {
                    result.Add(new KeyValuePair<NuGetPackage,UnsafePackage>(package, unsafePackage));
                }
            }
            return result;
        }
    }
}
