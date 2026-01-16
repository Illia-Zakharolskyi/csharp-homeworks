// .Net 9.0
using System;

namespace CardGame.src.Infastructure.Resolvers;

internal class PathResolver
{
    internal string ResolveRelativePathToFullPath(string relativePath)
    {
        return Path.Combine(AppContext.BaseDirectory, relativePath);
    }
}
