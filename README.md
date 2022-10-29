# master-thesis-game
An exergame to motivate players to exercise, without realizing they're exercising


## Getting started with Git and Unity

To set up the project on a new device follow the steps below.

1. Download Github Desktop
2. Use Github Desktop to clone this repo into a location you want it 
3. Download Unity Hub
4. We're using unity version `2021.3.11f1` for this project, so make sure that editor version is installed. This can be done in `Unity Hub -> Installs -> Install Editor`
5. Go to the `Projects` tab in Unity hub and click the arrow next to the `Open`button. Then click `add project from disk` and locate the folder you cloned earlier
6. Set the editor version to `2021.3.11f1` if it is not set already
7. Click on the project to open it, and start working =)


## How to push from and pull to Unity

During development we're using Github Desktop. Below we describe the process from of setting up a new branch to pushing and creating a pull request for it:
1. Navigate to the main branch (or another branch if you need unmerged changes) and pull any new changes
2. Create a new branch with an understandable name (include the issue nr. if you are working on a specific issue). Example: `#32-add-physics-to-play-board`
3. While on the new branch, do your changes in Unity or in your IDE of choice
4. When you are ready to commit your changes, go to Github Desktop
5. Select the changes you want. OBS:  ``Unity recalculates various things regularly, so don't be alarmed if there are more changes listed than you actually made.`` 
6. Write a short commit description including the issue nr. Ex. `#32 Add physics to play board`. You can add a longer description in the second field if the commit requires a longer explanation
7. Commit and push the changes
8. If you haven't done so already, publish the branch and create a pull request. Assign someone to review the pr.


## Reviewing pull requests

A quick overview of the different responsibilities for people involved in a pr:
- The original reviewer is responsible for merging the pr, and may do so when they feel the pr is ready (they can choose to approve the pr if they want)
- The person who submitted the pr is responsible for answering and resolving comments, unless they are waiting on conformation that the comment has been fixed in a good enough way

