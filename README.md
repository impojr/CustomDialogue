# CustomDialogue

## Conversations and Dialogues

### Conversations

A conversation is the UI that allows the player to initiate up to four different talk points with an NPC, as well as present any items in the inventory to them to start a conversation. The player opens up a conversation by walking up to an NPC and pressing the spacebar key.

Presenting an item or clicking on a talk point will start a dialogue with the NPC. When that dialogue is complete, the player will be returned to the conversation UI.

The player can exit the conversation UI by hitting the backspace key.

### Dialogues

A dialogue is the UI that shows a talking to the player. This will have the name and image of the person talking, as well as their current sentence displayed. Once the sentence has finised rendering, the player can hit the continue button to get the next sentence. Once all the sentences are displayed, the dialogue will disappear from view.

## Managers

### Conversation Manager

The conversation manager is responsible for displaying the correct conversation on the screen.

### Dialogue Manager

The dialogue manager is responsible for displaying the current dialogue on the screen.

## Initializers

### Conversation Initializer

The conversation initializer is responsible for initializing the list of conversations in the ConversationList class.
It also contains a function called `TriggerConversation(ActorList actor)` which will go through the list of Actors to see which one triggered the function, and will pass the conversation for that actor to the `ConversationManager` class.

### Dialogue Initializer

The dialogue initializer is responsible for initializing the list of dialogues in the DialogueList class.
It also contains a function called `TriggerDialogue(string key, bool returnToConversation)` which will go through the list of Dialogues to see which one triggered the function, and will pass the conversation for that dialogue to the `DialogueManager` class. The `returnToConversation` variable dictates whether or not the converation UI will reopen upon ending the conversation.

## Triggering a conversation

### `ConversationTrigger` class

The `ConversationTrigger` class sits on a game object in the player game object. It has a trigger collider on it, facing forward from the player. If it triggers with an NPC, it will store that NPC's info. If the player presses the space bar while still colliding, the conversation UI will appear.
When the player trigger no longer collides with the NPC, the stored information will be erased (to prevent starting a conversation when you are not near the NPC).

### `ActorSelector` class

For the `ConversationTrigger` to work correctly, it looks for a class called `ActorSelector` on the NPC object it collided with. The `ActorSelector` holds a single variable of the `ActorList` enum. This needs to be set in the inspector to the correct character to enable to dialogue to trigger correctly.

## Lists

### ActorList

`ActorList` is an enum of defined NPCS. This list is used by the `ActorSelector` class to enable the gameObjects in the scene to be ID'd as the correct NPCs.

### ConversationList

`ConversationList` is a static class of Conversations that can be called upon by the `ConversationInitializer` class. The `ConversationInitializer` class will look at which NPC conversation needs to be shown by comparing the NPC's `ActorSelector` `ActorList` variable, and then showing the appropriate `Conversation` from the `ConversationList`.

### DialogueList

`DialogueList` is a static class of Dialogues that can be called upon by the `DialogueInitializer` class. The `DialogueInitializer` class will look at which dialogue needs to be shown by comparing the string key it was passed, and then showing the dialogue array stored as it's value pair.

#### DialogueKeys

The `DialogueKey` class is a static class of keys. These are defined for use in the `DialogueList` and `ConversationList` classes, to ensure the values are always equal. The `Conversation` object's array of TextBoxes has it's text value equal to a dialogue key. This is so it can be displayed to the user, and if clicked on, that key can be used to show the correct dialogue.

## Inventory

The inventory is a class that holds the player's current items. These can be presented to NPCs to trigger events and dialogue.

### Item Database

The Item Database is a static class that contains a list of all items that can be placed in the inventory.

## Areas of Interest

Areas Of Interest are objects within the scene the player can interact with. They contain an item the player can pick up, and mandatory dialogue that can play. The AOI can also be destroyed after interaction.

### Area Of Interest Trigger

The `AreaOfInterestTrigger` triggers the player's response when interacting with an area of interest. Area's of Interest need to be tagged as `AreasOfInterest` for the collider to detect them.