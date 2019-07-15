using System.Collections.Generic;
using Constants;
using Dialogues;
using Dialogues.Chat;
using FriendZones;

namespace Controllers {
    public class GaugesDecisionMaker {
        private readonly FriendZonesController friendZonesController;
        private readonly DialogueGraph dialogueGraph;

        public GaugesDecisionMaker(FriendZonesController friendZonesController, DialogueGraph dialogueGraph) {
            this.friendZonesController = friendZonesController;
            this.dialogueGraph = dialogueGraph;
        }

        //TODO: Use commented versions when issue discussed in ChatNode is solved

/*        public int GetContinuationIndex() {
            ChatNode currentChatNode = dialogueGraph.currentChatNode;
            int firstValidConditionsListIndex =
                GetFirstListMeetingItsConditions(currentChatNode.continuationConditions);
            return firstValidConditionsListIndex > -1
                ? firstValidConditionsListIndex
                : currentChatNode.continuationConditions.Count - 1;
        }*/

        public int? GetContinuationIndex() {
            ChatNode currentChatNode = dialogueGraph.currentChatNode;
            int? firstValidConditionsListIndex =
                GetFirstListMeetingItsConditions(currentChatNode.continuationConditions, false);
            return firstValidConditionsListIndex > -1
                ? firstValidConditionsListIndex
                : currentChatNode.continuationConditions.Count - 1;
        }

/*        public void CheckForInterruptions() {
            ChatNode currentChatNode = dialogueGraph.currentChatNode;
            int firstValidConditionsListIndex =
                GetFirstListMeetingItsConditions(currentChatNode.interruptionConditions);
            if (firstValidConditionsListIndex > -1)
                dialogueGraph.currentChatNode.PickInterruptions(firstValidConditionsListIndex);
        }*/

        public void CheckForInterruptions() {
            ChatNode currentChatNode = dialogueGraph.currentChatNode;
            int? firstValidConditionsListIndex =
                GetFirstListMeetingItsConditions(currentChatNode.continuationConditions, true);
            if (firstValidConditionsListIndex != null)
                dialogueGraph.currentChatNode.PickContinuation(firstValidConditionsListIndex);
        }

/*        private int GetFirstListMeetingItsConditions(
            IReadOnlyList<ChatNodeConditionsList> chatNodeConditionsListList) {
            for (int i = 0; i < chatNodeConditionsListList.Count; i++) {
                ChatNodeConditionsList chatNodeConditionsList = chatNodeConditionsListList[i];
                bool areCurrentListConditionsMet = true;
                foreach (ChatNodeCondition chatNodeCondition in chatNodeConditionsList.chatNodeConditions) {
                    FriendZone friendZoneUnderCondition =
                        friendZonesController.EnumToFriendZone(chatNodeCondition.friendZonesEnum);
                    if ((chatNodeCondition.comparisonEnum == ComparisonEnum.Superior &&
                         friendZoneUnderCondition.Gauge.FillHeight <= chatNodeCondition.gaugeHeight)
                        || (chatNodeCondition.comparisonEnum == ComparisonEnum.Inferior &&
                            friendZoneUnderCondition.Gauge.FillHeight >= chatNodeCondition.gaugeHeight)
                        || (chatNodeCondition.comparisonEnum == ComparisonEnum.InferiorOrEqual &&
                            friendZoneUnderCondition.Gauge.FillHeight > chatNodeCondition.gaugeHeight)
                        || (chatNodeCondition.comparisonEnum == ComparisonEnum.SuperiorOrEqual &&
                            friendZoneUnderCondition.Gauge.FillHeight < chatNodeCondition.gaugeHeight)) {
                        areCurrentListConditionsMet = false;
                        break;
                    }
                }

                if (areCurrentListConditionsMet) return i;
            }

            return -1;
        }*/

        private int? GetFirstListMeetingItsConditions(
            IReadOnlyList<ChatNodeConditionsList> chatNodeConditionsListList,
            bool isInterrupting) {
            int? lastListMeetingsItsConditions = null; //TODO: Necessary until issue discussed in ChatNode gets solved

            for (int i = 0; i < chatNodeConditionsListList.Count; i++) {
                ChatNodeConditionsList chatNodeConditionsList = chatNodeConditionsListList[i];
                if (chatNodeConditionsList.isInterrupting != isInterrupting) continue;
                lastListMeetingsItsConditions = i;
                bool areCurrentListConditionsMet = true;
                foreach (ChatNodeCondition chatNodeCondition in chatNodeConditionsList.chatNodeConditions) {
                    FriendZone friendZoneUnderCondition =
                        friendZonesController.EnumToFriendZone(chatNodeCondition.friendZonesEnum);
                    if ((chatNodeCondition.comparisonEnum == ComparisonEnum.Superior &&
                         friendZoneUnderCondition.Gauge.FillHeight <= chatNodeCondition.gaugeHeight)
                        || (chatNodeCondition.comparisonEnum == ComparisonEnum.Inferior &&
                            friendZoneUnderCondition.Gauge.FillHeight >= chatNodeCondition.gaugeHeight)
                        || (chatNodeCondition.comparisonEnum == ComparisonEnum.InferiorOrEqual &&
                            friendZoneUnderCondition.Gauge.FillHeight > chatNodeCondition.gaugeHeight)
                        || (chatNodeCondition.comparisonEnum == ComparisonEnum.SuperiorOrEqual &&
                            friendZoneUnderCondition.Gauge.FillHeight < chatNodeCondition.gaugeHeight)) {
                        areCurrentListConditionsMet = false;
                        break;
                    }
                }

                if (areCurrentListConditionsMet) return i;
            }

            return isInterrupting ? null : lastListMeetingsItsConditions;
        }
    }
}