using System.Collections.Generic;
using Constants;
using Dialogues;
using FriendZones;

namespace Controllers {
    public class GaugesDecisionMaker {
        private readonly FriendZonesController friendZonesController;
        private readonly DialogueGraph dialogueGraph;

        public GaugesDecisionMaker(FriendZonesController friendZonesController, DialogueGraph dialogueGraph) {
            this.friendZonesController = friendZonesController;
            this.dialogueGraph = dialogueGraph;
        }

        public int GetAnswerIndex() {
            ChatNode currentChatNode = dialogueGraph.currentChatNode;
            int firstValidConditionsListIndex = GetFirstListMeetingItsConditions(currentChatNode.continuationConditions);
            return firstValidConditionsListIndex > -1
                ? firstValidConditionsListIndex
                : currentChatNode.continuationConditions.Count - 1;
        }

/*        public int CheckForInterruptions() {
            ChatNode currentChatNode = dialogueGraph.currentChatNode;
            int firstValidConditionsListIndex = GetFirstListMeetingItsConditions(currentChatNode.interruptions);
            return firstValidConditionsListIndex;
        }*/

        private int GetFirstListMeetingItsConditions(
            IReadOnlyList<ChatNodeConditionsList> chatNodeConditionsListList) {
            for (int i = 0; i < chatNodeConditionsListList.Count; i++) {
                ChatNodeConditionsList chatNodeConditionsList = chatNodeConditionsListList[i];
                bool areCurrentListConditionsMet = true;
                foreach (ChatNodeCondition chatNodeCondition in chatNodeConditionsList.chatNodeConditions) {
                    FriendZone friendZoneUnderCondition =
                        friendZonesController.EnumToFriendZone(chatNodeCondition.friendZonesEnum);
                    if ((chatNodeCondition.comparisonEnum == ComparisonEnum.Superior &&
                         friendZoneUnderCondition.Gauge.FillHeight < chatNodeCondition.gaugeHeight)
                        || (chatNodeCondition.comparisonEnum == ComparisonEnum.Inferior &&
                            friendZoneUnderCondition.Gauge.FillHeight >= chatNodeCondition.gaugeHeight)) {
                        areCurrentListConditionsMet = false;
                        break;
                    }
                }

                if (areCurrentListConditionsMet) return i;
            }

            return -1;
        }
    }
}