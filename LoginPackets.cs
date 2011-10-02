using IHI.Server.Messenger;
using IHI.Server.SubPackets;
using IHI.Server.Habbos;

using IHI.Server.Networking.Messages;
using IHI.Server.Networking;

namespace IHI.Server.Plugins.Cecer1.PacketSenders
{
    public static class LoginPackets
    {
        /// <summary>
        /// Send the secret key.
        /// </summary>
        /// <param name="Key">The key to send.</param>
        public static void Send_SecretKey(this PacketSender PS, string Key)
        {
            OutgoingMessage Message = new OutgoingMessage(1);
            Message.AppendString(Key);

            PS.GetUser().GetConnection().SendMessage(Message);
        }
        /// <summary>
        /// Sends two permissions. Not sure what this are yet
        /// </summary>
        /// <param name="Permission1">Not sure yet</param>
        /// <param name="Permission2">Not sure yet</param>
        public static void Send_Permissions(this PacketSender PS, bool Permission1, bool Permission2)
        {
            OutgoingMessage Message = new OutgoingMessage(2);   // "@B"

            Message.AppendBoolean(Permission1);
            Message.AppendBoolean(Permission2);

            PS.GetUser().GetConnection().SendMessage(Message);
        }
        /// <summary>
        /// Inform the client that it has been logged in.
        /// </summary>
        public static void Send_AuthenticationOK(this PacketSender PS)
        {
            OutgoingMessage Message = new OutgoingMessage(3);   // "@C"
            PS.GetUser().GetConnection().SendMessage(Message);
        }

        /// <summary>
        /// Send user data.
        /// </summary>
        /// <param name="UserID">The user ID.</param>
        /// <param name="Username">The username.</param>
        /// <param name="Figure">The figure.</param>
        /// <param name="Gender">The gender.</param>
        /// <param name="Motto">The motto.</param>
        /// <param name="SwimFigure">The swim figure in string form.</param>
        public static void Send_UserObject(this PacketSender PS, int UserID, string Username, string Figure, bool Gender, string Motto)
        {
            OutgoingMessage Message = new OutgoingMessage(5);   // "@E"

            Message.AppendString(UserID.ToString());
            Message.AppendString(Username);
            Message.AppendString(Figure);
            Message.AppendString(Gender ? "M" : "F"); // True = Male, False = Female
            Message.AppendString(Motto);
            Message.AppendString("UNKNOWN001");
            Message.AppendInt32(0);
            Message.Append((byte)2);
            Message.AppendInt32(0);
            Message.AppendInt32(0);
            Message.AppendInt32(10); // Respect apparently
            Message.AppendInt32(3); // Givable respect apparently
            Message.AppendInt32(5); // "Pet respect" apparently... I need to catch up on flash...

            PS.GetUser().GetConnection().SendMessage(Message);
        }
        /// <summary>
        /// Send the user credit balance.
        /// </summary>
        /// <param name="Balance"></param>
        public static void Send_CreditBalance(this PacketSender PS, int Balance)
        {
            OutgoingMessage Message = new OutgoingMessage(6);	// "@F"
            Message.AppendString(Balance.ToString());

            PS.GetUser().GetConnection().SendMessage(Message);

        }

        /// <summary>
        /// Send the initial messenger configuration and contents.
        /// </summary>
        /// <param name="A">Unsure</param>
        /// <param name="B">Unsure</param>
        /// <param name="C">Unsure</param>
        public static void Send_MessengerInit(this PacketSender PS, int A, int B, int C, Category[] Categories, Friend[] Friends, uint MaxFriends)
        {
            OutgoingMessage Message = new OutgoingMessage(12);	// "@L"
            Message.AppendInt32(A);     // Find out
            Message.AppendInt32(B);     // Find out
            Message.AppendInt32(C);     // Find out

            Message.AppendInt32(Categories.Length);

            for (int i = 0; i < Categories.Length; i++)
            {
                Message.AppendInt32(Categories[i].GetID());
                Message.AppendString(Categories[i].GetName());
            }

            Message.AppendInt32(Friends.Length);

            for (int i = 0; i < Friends.Length; i++)
            {
                Message.AppendObject(Friends[i]);
            }

            Message.AppendUInt32(MaxFriends);
            Message.AppendBoolean(false);       // TODO: Find out
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Categories">An array of all categories to show to the user.</param>
        /// <param name="Friends">An array of all friends to show to the user.</param>
        /// <param name="FriendUpdates">An array of all changes to the friends list to send to the user.</param>
        public static void Send_FriendListUpdate(this PacketSender PS, Category[] Categories, Friend[] Friends, FriendUpdate[] FriendUpdates)
        {
            OutgoingMessage Message = new OutgoingMessage(13);	// "@M"
            Message.AppendInt32(Categories.Length);

            for (int i = 0; i < Categories.Length; i++)
            {
                Message.AppendInt32(Categories[i].GetID());
                Message.AppendString(Categories[i].GetName());
            }

            Message.AppendInt32(Friends.Length + FriendUpdates.Length);

            for (int i = 0; i < FriendUpdates.Length; i++)
            {
                Message.AppendObject(FriendUpdates[i]);
            }

            for (int i = 0; i < Friends.Length; i++)
            {
                Message.AppendObject(Friends[i]);
            }
        }
        public static void Send_CloseConnection(PacketSender PS)
        {
            // HEADER: 18
        }
        public static void Send_OpenConnection(PacketSender PS)
        {
            // HEADER: 19
        }
        public static void Send_Chat(PacketSender PS)
        {
            // HEADER: 24
        }
        public static void Send_Whisper(PacketSender PS)
        {
            // HEADER: 25
        }
        public static void Send_Shout(PacketSender PS)
        {
            // HEADER: 26
        }
        public static void Send_Users(PacketSender PS)
        {
            // HEADER: 28
        }
        public static void Send_UserRemove(PacketSender PS)
        {
            // HEADER: 29
        }
        public static void Send_HeightMap()
        {
            // HEADER: 31
        }
        public static void Send_Objects()
        {
            // HEADER: 32
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Send_GenericError(this PacketSender PS, string A, string B)
        {
            OutgoingMessage Message = new OutgoingMessage(33); // "@a"

            Message.AppendString(A);
            Message.AppendString(B);

            PS.GetUser().GetConnection().SendMessage(Message);
        }
        /*public static void Send_UserUpdate()
        {
            // HEADER: 34
        }
        public static void Send_UserBanned()
        {
            // HEADER: 35
        }
        public static void Send_FlatAccessible()
        {
            // HEADER: 41
        }
        public static void Send_YouAreController()
        {
            // HEADER: 42
        }
        public static void Send_YouAreNotController()
        {
            // HEADER: 43
        }
        public static void Send_NoSuchFlat()
        {
            // HEADER: 44
        }
        public static void Send_Items()
        {
            // HEADER: 45
        }
        public static void Send_RoomProperty()
        {
            // HEADER: 46
        }
        public static void Send_YouAreOwner()
        {
            // HEADER: 47
        }
        public static void Send_ItemDataUpdate()
        {
            // HEADER: 48
        }
        public static void Send_Ping()
        {
            // HEADER: 50
        }
        public static void Send_FlatCreated()
        {
            // HEADER: 59
        }
        public static void Send_DoorOtherEndDeleted()
        {
            // HEADER: 63
        }
        public static void Send_DoorNotInstalled()
        {
            // HEADER: 64
        }
        public static void Send_PurchaseError()
        {
            // HEADER: 65
        }
        public static void Send_PurchaseOK()
        {
            // HEADER: 67
        }
        public static void Send_NotEnoughBalance()
        {
            // HEADER: 68
        }
        public static void Send_RoomReady()
        {
            // HEADER: 69
        }
        public static void Send_ItemAdd()
        {
            // HEADER: 83
        }
        public static void Send_ItemRemove()
        {
            // HEADER: 84
        }
        public static void Send_ItemUpdate()
        {
            // HEADER: 85
        }
        public static void Send_ObjectDataUpdate()
        {
            // HEADER: 88
        }
        public static void Send_DiceValue()
        {
            // HEADER: 90
        }
        public static void Send_Doorbell()
        {
            // HEADER: 91
        }
        public static void Send_ObjectAdd()
        {
            // HEADER: 93
        }
        public static void Send_ObjectRemove()
        {
            // HEADER: 94
        }
        public static void Send_ObjectUpdate()
        {
            // HEADER: 95
        }
        public static void Send_FurniListInsert()
        {
            // HEADER: 98
        }
        public static void Send_FurniListRemove()
        {
            // HEADER: 99
        }
        public static void Send_FurniListUpdate()
        {
            // HEADER: 101
        }
        public static void Send_TradingYouAreNotAllowed()
        {
            // HEADER: 102
        }
        public static void Send_TradingOtherNotAllowed()
        {
            // HEADER: 103
        }
        public static void Send_TradingOpen()
        {
            // HEADER: 104
        }
        public static void Send_TradingAlreadyOpen()
        {
            // HEADER: 105
        }
        public static void Send_TradingNotOpen()
        {
            // HEADER: 106
        }
        public static void Send_TradingNoSuchItem()
        {
            // HEADER: 107
        }
        public static void Send_TradingItemList()
        {
            // HEADER: 108
        }
        public static void Send_TradingAccept()
        {
            // HEADER: 109
        }
        public static void Send_TradingClose()
        {
            // HEADER: 110
        }
        public static void Send_TradingConfirmation()
        {
            // HEADER: 111
        }
        public static void Send_TradingCompleted()
        {
            // HEADER: 112
        }
        public static void Send_CatalogIndex()
        {
            // HEADER: 126
        }
        public static void Send_CatalogPage()
        {
            // HEADER: 127
        }
        public static void Send_PresentOpened()
        {
            // HEADER: 129
        }
        public static void Send_FlatAccessDenied()
        {
            // HEADER: 131
        }
        public static void Send_NewBuddyRequest()
        {
            // HEADER: 132
        }
        public static void Send_NewConsole()
        {
            // HEADER: 134
        }
        public static void Send_RoomInvite()
        {
            // HEADER: 135
        }*/
        public static void Send_StandardNotice(this PacketSender PS, string Content, string URL)
        {
            OutgoingMessage Message = new OutgoingMessage(139);

            Message.AppendString(Content);
            Message.AppendString(URL);

            PS.GetUser().GetConnection().SendMessage(Message);
        }
        /*public static void Send_FurniList()
        {
            // HEADER: 140
        }
        public static void Send_PostItPlaced()
        {
            // HEADER: 145
        }
        public static void Send_Mod()
        {
            // HEADER: 161
        }
        public static void Send_VoucherRedeemOk()
        {
            // HEADER: 212
        }
        public static void Send_VoucherRedeemError()
        {
            // HEADER: 213
        }
        public static void Send_HeightMapUpdate()
        {
            // HEADER: 219
        }
        public static void Send_UserFlatCats()
        {
            // HEADER: 221
        }
        public static void Send_FlatCat()
        {
            // HEADER: 222
        }
        public static void Send_HabboUserBadges()
        {
            // HEADER: 228
        }
        public static void Send_Badges()
        {
            // HEADER: 229
        }
        public static void Send_SlideObjectsBundle()
        {
            // HEADER: 230
        }*/
        /// <summary>
        /// TODO: MAJOR packet sorting!
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <param name="E"></param>
        /// <param name="F"></param>
        /// <param name="G"></param>
        /// <param name="H"></param>
        /// <param name="I"></param>
        /// <param name="J"></param>
        /// <param name="K"></param>
        /// <param name="L"></param>
        /// <param name="DateFormat"></param>
        /// <param name="M"></param>
        /// <param name="N"></param>
        /// <param name="O"></param>
        /// <param name="URL"></param>
        /// <param name="P"></param>
        /// <param name="Q"></param>
        public static void Send_SessionParams(this PacketSender PS, int A, int B, int C, int D, int E, int F, int G, int H, int I, int J, int K, int L, string DateFormat, int M, int N, int O, string URL, int P, int Q)
        {
            OutgoingMessage Message = new OutgoingMessage(257); // "DA"

            Message.AppendInt32(A);
            Message.AppendInt32(B);
            Message.AppendInt32(C);
            Message.AppendInt32(D);
            Message.AppendInt32(E);
            Message.AppendInt32(F);
            Message.AppendInt32(G);
            Message.AppendInt32(H);
            Message.AppendInt32(I);
            Message.AppendInt32(J);
            Message.AppendInt32(K);
            Message.AppendInt32(L);
            Message.AppendString(DateFormat);
            Message.AppendInt32(M);
            Message.AppendInt32(N);
            Message.AppendInt32(O);
            Message.AppendString(URL);
            Message.AppendInt32(P);
            Message.AppendInt32(Q);

            PS.GetUser().GetConnection().SendMessage(Message);
        }/*
                public static void Send_MessengerError()
                {
                    // HEADER: 260
                }
                public static void Send_InstantMessageError()
                {
                    // HEADER: 261
                }
                public static void Send_RoomInviteError()
                {
                    // HEADER: 262
                }
                public static void Send_UserChange()
                {
                    // HEADER: 266
                }*/

        /// <summary>
        /// Encryption is not supported by IHI.
        /// This is part of the no encryption setting that seems to work.
        /// </summary>
        /// <param name="Token">Educated Guess</param>
        public static void Send_InitCrypto(this PacketSender PS, string Token, bool Status)
        {
            // TODO: Unused?
            // HEADER: 277
            OutgoingMessage Message = new OutgoingMessage(277); // TODO: // "HEADER"
            if (Status)
                Message.AppendString(Token);
            else
                Message.AppendString(string.Empty);
            Message.AppendBoolean(Status);

            PS.GetUser().GetConnection().SendMessage(Message);
        }
        /*
        public static void Send_RoomForward()
        {
            // HEADER: 286
        }
        */
        public static void Send_ConnectionClosed(this PacketSender PS, ConnectionClosedReason Reason)
        {
            OutgoingMessage Message = new OutgoingMessage(287);

            Message.AppendInt32((int)Reason);

            PS.GetUser().GetConnection().SendMessage(Message);
        }
        public static void Send_Unknown290(this PacketSender PS, bool a, bool b)
        {
            OutgoingMessage Message = new OutgoingMessage(290);

            Message.AppendBoolean(a); // TODO: Figure this out
            Message.AppendBoolean(b);

            PS.GetUser().GetConnection().SendMessage(Message);
        }
        /*public static void Send_PurchaseNotAllowed()
        {
            // HEADER: 296
        }
        public static void Send_ErrorReport()
        {
            // HEADER: 299
        }
        public static void Send_HabboGroupsBadges()
        {
            // HEADER: 309
        }
        public static void Send_OneWayDoorStatus()
        {
            // HEADER: 312
        }*/
        public static void Send_FriendRequests(Database.MessengerFriendRequest[] Requests)
        {

            // HEADER: 314
        }
        public static void Send_AcceptBuddyResult()
        {
            // HEADER: 315
        }
        public static void Send_RoomRating()
        {
            // HEADER: 345
        }
        public static void Send_FollowFriendFailed()
        {
            // HEADER: 349
        }
        public static void Send_UserTags()
        {
            // HEADER: 350
        }
        public static void Send_UserTyping()
        {
            // HEADER: 361
        }
        public static void Send_RoomDimmer()
        {
            // HEADER: 365
        }
        public static void Send_CanCreateRoomEvent()
        {
            // HEADER: 367
        }
        public static void Send_RoomEvent()
        {
            // HEADER: 370
        }
        public static void Send_IgnoreResult()
        {
            // HEADER: 419
        }
        public static void Send_IgnoredUsers()
        {
            // HEADER: 420
        }
        public static void Send_HabboSearchResult()
        {
            // HEADER: 435
        }
        public static void Send_Achievements()
        {
            // HEADER: 436
        }
        public static void Send_HabboAcievementNotification()
        {
            // HEADER: 437
        }
                
        /// <summary>
        /// Something to do with pixels?
        /// </summary>
        /// <param name="PS"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        public static void Send_HabboActivityPointNotification(this PacketSender PS, int A, int B, int C)
        {
            OutgoingMessage Message = new OutgoingMessage(538); // HEADER: "Fv"

            Message.AppendInt32(A);
            Message.AppendInt32(B);
            Message.AppendInt32(C);

            PS.GetUser().GetConnection().SendMessage(Message);
        }
        
        public static void Send_UniqueMachineID()
        {
            // HEADER: 439
        }
        public static void Send_RespectNotification()
        {
            // HEADER: 440
        }
        public static void Send_CatalogPublished()
        {
            // HEADER: 441
        }
        
        public static void Send_Unknown443(this PacketSender PS, int A)
        {
            OutgoingMessage Message = new OutgoingMessage(443); // "F{"

            Message.AppendInt32(A);

            PS.GetUser().GetConnection().SendMessage(Message);
        }
        public static void Send_NavigatorFrontPageResult()
        {
            // HEADER: 450
        }
        public static void Send_GuestRoomSearchResult(this PacketSender PS)
        {
            OutgoingMessage Message = new OutgoingMessage(451); // "GC"

            Message.AppendInt32(0);

            PS.GetUser().GetConnection().SendMessage(Message);
        }
        /*
        public static void Send_PopularRoomTagsResult()
        {
            // HEADER: 452
        }
        public static void Send_OfficialRoomsResult()
        {
            // HEADER: 453
        }
        public static void Send_GetGuestRoomResult()
        {
            // HEADER: 454
        }
        public static void Send_NavigatorSettings()
        {
            // HEADER: 455
        }
        public static void Send_RoomInfoUpdated()
        {
            // HEADER: 456
        }
        public static void Send_RoomThumbnailUpdateResult()
        {
            // HEADER: 457
        }
        public static void Send_Favourites()
        {
            // HEADER: 458
        }
        public static void Send_FavouriteChanged()
        {
            // HEADER: 459
        }
        public static void Send_AvatarEffects()
        {
            // HEADER: 460
        }
        public static void Send_AvatarEffectAdded()
        {
            // HEADER: 461
        }
        public static void Send_AvatarEffectActivated()
        {
            // HEADER: 462
        }
        public static void Send_AvatarEffectExpired()
        {
            // HEADER: 463
        }
        public static void Send_AvatarEffectSelected()
        {
            // HEADER: 464
        }
        public static void Send_RoomSettingsData()
        {
            // HEADER: 465
        }
        public static void Send_RoomSettingsError()
        {
            // HEADER: 466
        }
        public static void Send_RoomSettingsSaved()
        {
            // HEADER: 467
        }
        public static void Send_RoomSettingsSaveError()
        {
            // HEADER: 468
        }
        public static void Send_FloorHeightMap()
        {
            // HEADER: 470
        }
        public static void Send_RoomEntryInfo()
        {
            // HEADER: 471
        }
        public static void Send_Dance()
        {
            // HEADER: 480
        }
        public static void Send_Wave()
        {
            // HEADER: 481
        }
        public static void Send_CarryObject()
        {
            // HEADER: 482
        }
        public static void Send_AvatarEffect()
        {
            // HEADER: 485
        }
        public static void Send_Sleep()
        {
            // HEADER: 486
        }
        public static void Send_UserObject()
        {
            // HEADER: 488
        }
        public static void Send_FlatControllerAdded()
        {
            // HEADER: 510
        }
        public static void Send_FlatControllerRemoved()
        {
            // HEADER: 511
        }
        public static void Send_CanCreateRoom()
        {
            // HEADER: 512
        }
        public static void Send_PlaceObjectError()
        {
            // HEADER: 516
        }*/
        public static void Send_InfoFeedEnable(this PacketSender PS, bool Enabled)
        {
            OutgoingMessage Message = new OutgoingMessage(517);

            Message.AppendBoolean(Enabled);

            PS.GetUser().GetConnection().SendMessage(Message);
        }

        public static void Send_InitModTool(this PacketSender PS, int a, string[] PresetUserMessages, string[] PresetRoomMessages)
        {
            OutgoingMessage Message = new OutgoingMessage(531);

            Message.AppendInt32(a); // TODO: Figure this out
            Message.AppendInt32(PresetUserMessages.Length);

            foreach (string PresetMessage in PresetUserMessages)
            {
                Message.AppendString(PresetMessage);
            }

            Message.AppendInt32(0);     // TODO: Figure this out
            Message.AppendInt32(14);    // TODO: Figure this out
            Message.AppendInt32(1);     // TODO: Figure this out
            Message.AppendInt32(1);     // TODO: Figure this out
            Message.AppendInt32(1);     // TODO: Figure this out
            Message.AppendInt32(1);     // TODO: Figure this out
            Message.AppendInt32(1);     // TODO: Figure this out
            Message.AppendInt32(1);     // TODO: Figure this out

            Message.AppendInt32(PresetRoomMessages.Length);

            foreach (string PresetMessage in PresetUserMessages)
            {
                Message.AppendString(PresetMessage);
            }

            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendString("test");   // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendString("test");   // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendInt32(1);         // TODO: Figure this out         
            Message.AppendString("test");   // TODO: Figure this out

            PS.GetUser().GetConnection().SendMessage(Message);
        }

        public static void Send_MessageOfTheDay(this PacketSender PS, int A, string Content)
        {
            OutgoingMessage Message = new OutgoingMessage(810); // HEADER: "Lj"

            Message.AppendInt32(A);
            Message.AppendString(Content);

            PS.GetUser().GetConnection().SendMessage(Message);
        }
    }
}