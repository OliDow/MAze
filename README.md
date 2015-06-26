Maze Notes

Maze
- ItemList

MazeItem
 - XCord
 - YCord
 - Type (Enum - Start, End, Space, Wall)

MazeService
- ReadMap - Input Text and create Map
- ViewMap - Print Map
- Viewitem - View a specific cord
- Stats - Display Wall/Space count


ExplorerClass
 - Direction
 - xCord
 - yCord
 - ActionLog

ExplorerService
- LogAction
- DoAction
-- Turn Left
-- Turn Right
-- Move Forward
-- Look Forward
-- Look Around
- AutoComplete
