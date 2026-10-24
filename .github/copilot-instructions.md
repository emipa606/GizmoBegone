# GitHub Copilot Instructions for Gizmo Begone! (Continued)

## Mod Overview and Purpose

Gizmo Begone! (Continued) is a RimWorld mod that hides unwanted gizmos and buildable options from the game's Architect tab. This helps reduce clutter and improve the player's experience by allowing them to focus on what they actually want to build.

## Key Features and Systems

### Hide Gizmos
- The mod hides gizmos for selected ThingDefs and TerrainDefs, making them unavailable in the Architect tab.
- Users can customize which gizmos to hide through the mod's settings menu.

### Search by Mod Name
- A search bar in the settings allows users to filter gizmos by the mod they come from, making it easier to identify and manage.

### Tooltip for Mod Origin
- A tooltip shows which mod each gizmo belongs to, providing additional context for users.

### Compatibility
- The mod is compatible with most other mods but may have conflicts with others like RIMMSqol and Raise The Roof.

## Coding Patterns and Conventions

- **Modding Framework**: The mod follows the standard RimWorld modding framework, utilizing XML for configuration and C# for core functionality.
- **Harmony Patching**: Harmony is used for patching existing game methods to add or modify behavior.
- **Code Organization**: Code is organized into meaningful namespaces and classes to maintain readability and maintainability.
- **Settings Management**: Settings are handled through a custom settings class that exposes data and writes settings to XML.

## XML Integration

The mod uses XML files for configuration:

- **Manifest.xml**: Contains metadata about the mod, such as its name, version, and dependencies.
- **About.xml**: Provides additional information about the mod, including its author and dependencies.

## Harmony Patching

Harmony is used to patch the following method:

- **Designator_Build.PostDesignate**: This method is patched to prevent the designation of hidden gizmos.

Example Harmony patch:
csharp
[HarmonyPatch(typeof(Designator_Build), nameof(Designator_Build.PostDesignate))]
public static class Designator_Build_Patch
{
    public static void Postfix(Designator_Build __instance)
    {
        if (ThingBegone.HiddenGizmos.Contains(__instance.ThingDef))
        {
            __instance.Revoke();
        }
    }
}


## Suggestions for Copilot

### General Suggestions
- **Documentation**: Ensure that all methods and classes have comprehensive XML comments explaining their purpose and usage.
- **Testing**: Add unit tests for critical functionality, such as gizmo hiding and settings management.
- **Performance**: Optimize code to ensure it does not introduce performance bottlenecks, especially when handling large lists of ThingDefs.

### C# File Suggestions
- **Startup.cs**: This class should handle initialization tasks, such as loading settings and registering Harmony patches.
- **Settings\ThingBegone.cs**: This class should manage the settings UI and ensure that settings are correctly exposed and saved.
- **Core\Designator_Build_Visible.cs**: This class should contain logic for determining whether a gizmo should be visible or hidden.

### XML File Suggestions
- **Manifest.xml**: Ensure that all dependencies are correctly listed and that the mod's version is up-to-date.
- **About.xml**: Include detailed information about the mod, such as its purpose, author, and any known issues or conflicts.

## Conclusion

By following these guidelines, developers can contribute to the Gizmo Begone! (Continued) mod in a way that is consistent with the mod's coding standards and enhances its functionality and usability.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

