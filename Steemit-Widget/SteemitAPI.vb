Imports Newtonsoft.Json
Imports Newtonsoft.Json.Converters

Public Class SteemitAPI
    Public Class Owner
        Public Property weight_threshold As Integer
        Public Property account_auths As Object()
        Public Property key_auths As Object()()
    End Class

    Public Class Active
        Public Property weight_threshold As Integer
        Public Property account_auths As Object()
        Public Property key_auths As Object()()
    End Class

    Public Class Posting
        Public Property weight_threshold As Integer
        Public Property account_auths As Object()
        Public Property key_auths As Object()()
    End Class

    Public Class PendingResetAuthority
        Public Property weight_threshold As Integer
        Public Property account_auths As Object()
        Public Property key_auths As Object()
    End Class

    Public Class BlogCategory
    End Class

    Public Class steem_api
        Public Property id As String
        Public Property name As String
        Public Property owner As List(Of Owner)
        Public Property active As List(Of Active)
        Public Property posting As List(Of Posting)
        Public Property memo_key As String
        Public Property json_metadata As String
        Public Property proxy As String
        Public Property last_owner_update As DateTime
        Public Property last_account_update As DateTime
        Public Property created As DateTime
        Public Property mined As Boolean
        Public Property owner_challenged As Boolean
        Public Property active_challenged As Boolean
        Public Property last_owner_proved As DateTime
        Public Property last_active_proved As DateTime
        Public Property recovery_account As String
        Public Property last_account_recovery As DateTime
        Public Property reset_account As String
        Public Property comment_count As Integer
        Public Property lifetime_vote_count As Integer
        Public Property post_count As Integer
        Public Property can_vote As Boolean
        Public Property voting_power As Integer
        Public Property last_vote_time As DateTime
        Public Property balance As String
        Public Property savings_balance As String
        Public Property sbd_balance As String
        Public Property sbd_seconds As String
        Public Property sbd_seconds_last_update As DateTime
        Public Property sbd_last_interest_payment As DateTime
        Public Property savings_sbd_balance As String
        Public Property savings_sbd_seconds As String
        Public Property savings_sbd_seconds_last_update As DateTime
        Public Property savings_sbd_last_interest_payment As DateTime
        Public Property savings_withdraw_requests As Integer
        Public Property vesting_shares As String
        Public Property vesting_withdraw_rate As String
        Public Property next_vesting_withdrawal As DateTime
        Public Property withdrawn As Integer
        Public Property to_withdraw As Integer
        Public Property withdraw_routes As Integer
        Public Property curation_rewards As Integer
        Public Property posting_rewards As Integer
        Public Property proxied_vsf_votes As Integer()
        Public Property witnesses_voted_for As Integer
        Public Property average_bandwidth As Integer
        Public Property lifetime_bandwidth As String
        Public Property last_bandwidth_update As DateTime
        Public Property average_market_bandwidth As Integer
        Public Property last_market_bandwidth_update As DateTime
        Public Property last_post As DateTime
        Public Property last_root_post As DateTime
        Public Property post_bandwidth As Integer
        Public Property pending_reset_authority As List(Of PendingResetAuthority)
        Public Property reset_request_time As DateTime
        Public Property vesting_balance As String
        Public Property reputation As String
        Public Property transfer_history As Object()
        Public Property market_history As Object()
        Public Property post_history As Object()
        Public Property vote_history As Object()
        Public Property other_history As Object()
        Public Property witness_votes As String()
        Public Property blog_category As List(Of BlogCategory)
    End Class

#Region "custom converter"
    Class CustomConverter
        Inherits CustomCreationConverter(Of IDictionary(Of String, Object))
        Public Overrides Function Create(objectType As Type) As IDictionary(Of String, Object)
            Return New Dictionary(Of String, Object)()
        End Function

        Public Overrides Function CanConvert(objectType As Type) As Boolean
            ' in addition to handling IDictionary<string, object>
            ' we want to handle the deserialization of dict value
            ' which is of type object
            Return objectType = GetType(Object) OrElse MyBase.CanConvert(objectType)
        End Function

        Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
            If reader.TokenType = JsonToken.StartObject OrElse reader.TokenType = JsonToken.Null Then
                Return MyBase.ReadJson(reader, objectType, existingValue, serializer)
            End If

            ' if the next token is not an object
            ' then fall back on standard deserializer (strings, numbers etc.)
            Return serializer.Deserialize(reader)
        End Function
    End Class
#End Region
End Class
