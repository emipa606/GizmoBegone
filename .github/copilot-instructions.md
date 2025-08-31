# Copilot Instructions for "Gizmo Begone! (Continued)"

## Mod Overview and Purpose

**Gizmo Begone! (Continued)** is a RimWorld mod designed to help players declutter their game interface by hiding unwanted build Gizmos (buttons). These Gizmos typically appear on the Architect tab and can occupy significant space on the screen, becoming a visual nuisance. Unlike mods that remove game content, this mod maintains all game definitions intact—only affecting the visibility of certain buttons. This makes for a cleaner and more organized gameplay experience without altering core game mechanics.

## Key Features and Systems

- **Tooltip Enhancement**: In the options, players can now view tooltips providing details about the mod that each gizmo originates from.
- **Enhanced Search Functionality**: The search bar capability is enhanced to include mod names associated with each gizmo for a more refined search experience.
- **Non-Intrusive Design**: It hides build options visually without removing any `ThingDefs` or `TerrainDefs`.
- **Compatibility**: The mod supports multiple game versions, with recent support added for version 1.2.

## Coding Patterns and Conventions

- **Consistent Naming**: Class names are PascalCase, reflecting their purpose clearly (e.g., `Designator_Build_Visible`, `ThingBegone`).
- **Method Overloading**: Methods in `SwitchWidget.cs` are overloaded to handle different types of definitions (e.g., `Button(ThingDef thing, Vector2 vector)` and `Button(TerrainDef terrain, Vector2 vector)`).
- **Access Modifiers**: The mod employs a mix of `public` and `internal` access modifiers to define visibility and encapsulation of classes and methods appropriately.

## XML Integration

- The XML portion is crucial for linking C# logic to the RimWorld game. Pay close attention to how each `ThingDef` and `TerrainDef` is declared in the XML and ensure they match accordingly in the C# definitions for proper functionality.
- XML files should include clear comments and utilize attributes like `ParentName` for easy inheritance of properties.

## Harmony Patching

- **Harmony Library**: The mod utilizes Harmony for runtime code modification, allowing for seamless integration and addition of features without altering the base game code. 
- Focus on patches that specifically target methods related to the visibility of Gizmos rather than their existence. Ensure that patches do not affect save-game stability or core game mechanics.
- Use `[HarmonyPatch]` and associated techniques to replace or extend existing game logic without introducing conflicts, especially when dealing with core UI classes.

## Suggestions for Copilot

- **Class and Method Stubs**: Generate stubs for any missing methods or classes required for expanded functionality, such as additional UI components that need gizmo management.
- **Debugging Assistance**: Provide logging statements to aid in tracking method execution, especially when debugging visibility toggling issues.
- **Testing and Compatibility**: Suggest tests for compatibility with known conflicting mods like "RIMMSqol" and "Raise The Roof". This may involve conditional logic to handle specific mod states or settings.
- **Code Documentation**: Encourage the addition of XML comments for public methods and classes to aid future developers in understanding the codebase and extending functionality.

This file provides the necessary guidelines and context required for Copilot to assist efficiently in the development and maintenance of the Gizmo Begone mod. By following these structured approaches and leveraging automation, developers can ensure smooth mod operation and consistent player experience.
