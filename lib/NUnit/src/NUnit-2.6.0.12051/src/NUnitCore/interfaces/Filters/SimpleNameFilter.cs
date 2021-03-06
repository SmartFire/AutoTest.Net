// ****************************************************************
// Copyright 2007, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org
// ****************************************************************
using System;
using System.Collections;

namespace NUnit.Core.Filters
{
	/// <summary>
	/// SimpleName filter selects tests based on their name
	/// </summary>
    [Serializable]
    public class SimpleNameFilter : TestFilter
    {
        private ArrayList names = new ArrayList();

		/// <summary>
		/// Construct an empty SimpleNameFilter
		/// </summary>
        public SimpleNameFilter() { }

        /// <summary>
        /// Construct a SimpleNameFilter for a single name
        /// </summary>
        /// <param name="name">The name the filter will recognize.</param>
        public SimpleNameFilter(string name)
        {
            names.Add(name);
        }

        /// <summary>
        /// Construct a SimpleNameFilter for an array of names
        /// </summary>
        /// <param names="nameToAdd">The names the filter will recognize.</param>
        public SimpleNameFilter(string[] namesToAdd)
        {
            this.names.AddRange(namesToAdd);
        }

        /// <summary>
        /// Add a name to a SimpleNameFilter
        /// </summary>
        /// <param name="name">The name to be added.</param>
        public void Add(string name)
        {
            names.Add(name);
        }

        /// <summary>
        /// Add an array of names to a SimpleNameFilter
        /// </summary>
        /// <param name="namesToAdd">The name to be added.</param>
        public void Add(string[] namesToAdd)
        {
            foreach (string name in namesToAdd)
                names.Add(name);
        }

        /// <summary>
		/// Check whether the filter matches a test
		/// </summary>
		/// <param name="test">The test to be matched</param>
		/// <returns>True if it matches, otherwise false</returns>
		public override bool Match( ITest test )
		{
			foreach( string name in names )
				if ( test.TestName.FullName == name )
					return true;

			return false;
		}
	}
}
