using System.IO;
using System.Linq;

public class UtilFunction {

    public static string PathCombine(string[] arr) {
        return arr.Aggregate((path1, path2) => {
            return Path.Combine(path1, path2);
        });
    }

}