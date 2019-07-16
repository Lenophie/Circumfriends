using Constants;

namespace Dialogues.Events {
    /**
     * This Node is used to end a dialogue graph by changing scene
     */
    [CreateNodeMenu("FinalNodes/SceneChange")]
    public class SceneChangeEventNode : EventNode {
        public SceneChangeEvent sceneChangeEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.SceneChange,
                sceneChangeEvent);
            base.Trigger();
        }
    }
}