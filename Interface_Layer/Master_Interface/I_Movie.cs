using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Layer.Master_Model;

namespace Interface_Layer.Master_Interface
{
	public interface I_Movie
	{
		string SaveUpdate(Movie _movie);
		List<Movie> List();
		Movie Edit(int id);
		int Delete(int id);

	}
}
