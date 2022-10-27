# master-thesis-game
An exergame to motivate players to exercise, without realizing they're exercising


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

