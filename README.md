# RaraChallenge

## Description of the Design

I separated the main features of the application in different classes and interfaces to increase scalability by using composition.

The ApplicationView is the base that initializes the game with the only “void Start()” function to avoid unintended race conditions.

Once you press Play, a new GameState is created and it's given all the scene entities so it can start and reset them as the game stops being tested.
EditorUIView is the main class that controls the “Edit Mode” and it's windows


## Things i could have done if i had more time

- When selecting which behaviour represents a button, I would have created a custom inspector that searches all behaviour types by reflection ( +scalability -performance)

- When creating an entity, add behaviour with reflection instead of an switch statement ( +scalability -performance)

- Saving user created entities to playerprefs
- Saving user created scene to playerprefs

- views have too much logic, I would've separated them into controller classes, bonus points for doing it with TDD

- Selection and removal of user created entities on editor and on scene

- camera movement while entity to create is deselected

- behaviour selector it's just buttons, there is no feedback whether one or more behaviours are selected, also you can't deselect one, you have to clear all by selecting "None"
