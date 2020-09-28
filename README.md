
# MVP Presenter First example

After reading the article ["Is Presenter First Still Valuable to Modern App Architecture?"](https://spin.atomicobject.com/2015/03/11/presenter-first-modern-architecture/) I decided to expand the examples of the Presenter implementation shown there. Based on the original Java examples, I created complete C# projects that also included unit tests and the user interface.

The first example is a logic-rich presenter working with a stateless model. The presenter actively manages the data flow between the view and the model. To make it possible, the interface of the Model with which the Presenter works must be sufficiently detailed.

You can ask yourself whether the Presenter has too much responsibility and whether the Model correctly encapsulates its logic?
