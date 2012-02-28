/*
 * Author: Kishore Reddy
 * Url: http://commonlibrarynet.codeplex.com/
 * Title: CommonLibrary.NET
 * Copyright: � 2009 Kishore Reddy
 * License: LGPL License
 * LicenseUrl: http://commonlibrarynet.codeplex.com/license
 * Description: A C# based .NET 3.5 Open-Source collection of reusable components.
 * Usage: Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ComLib.Entities;
using ComLib.LocationSupport;
using ComLib.ValidationSupport;



namespace ComLib.Web.Modules.MenuEntrys
{
    /// <summary>
    /// MenuEntry entity.
    /// </summary>
    public partial class MenuEntry : ActiveRecordBaseEntity<MenuEntry>, IEntity
    {
        /// <summary>
        /// Creates a new instance of BlogPost and 
        /// initializes it with a validator and settings.
        /// </summary>
        /// <returns></returns>
        public static MenuEntry New()
        {
            MenuEntry entity = new MenuEntry(); 
            return entity;
        }       


        		/// <summary>
		/// Get/Set AppId
		/// </summary>
		public int AppId { get; set; }


		/// <summary>
		/// Get/Set Name
		/// </summary>
		public string Name { get; set; }


		/// <summary>
		/// Get/Set Url
		/// </summary>
		public string Url { get; set; }


		/// <summary>
		/// Get/Set Description
		/// </summary>
		public string Description { get; set; }


		/// <summary>
		/// Get/Set Roles
		/// </summary>
		public string Roles { get; set; }


		/// <summary>
		/// Get/Set ParentItem
		/// </summary>
		public string ParentItem { get; set; }


		/// <summary>
		/// Get/Set RefId
		/// </summary>
		public int RefId { get; set; }


		/// <summary>
		/// Get/Set IsRerouted
		/// </summary>
		public bool IsRerouted { get; set; }


		/// <summary>
		/// Get/Set SortIndex
		/// </summary>
		public int SortIndex { get; set; }




        
        
    }
}
