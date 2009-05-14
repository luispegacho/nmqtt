﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Nmqtt
{
    /// <summary>
    /// Implementation of an MQTT Publish Acknowledgement Message, used to ACK a publish message that has it's QOS set to AtLeast or Exactly Once.
    /// </summary>
    public sealed class MqttPublishAckMessage : MqttMessage
    {
        /// <summary>
        /// Gets or sets the variable header contents. Contains extended metadata about the message
        /// </summary>
        /// <value>The variable header.</value>
        public MqttPublishAckVariableHeader VariableHeader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttPublishMessage"/> class.
        /// </summary>
        /// <remarks>
        /// Only called via the MqttMessage.Create operation during processing of an Mqtt message stream.
        /// </remarks>
        public MqttPublishAckMessage()
        {
            this.Header = new MqttHeader()
            {
                MessageType = MqttMessageType.PublishAck
            };

            this.VariableHeader = new MqttPublishAckVariableHeader()
            {
                ConnectFlags = new MqttConnectFlags()
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttConnectMessage"/> class.
        /// </summary>
        /// <param name="messageStream">The message stream positioned after the header.</param>
        internal MqttPublishAckMessage(MqttHeader header, Stream messageStream)
        {
            this.Header = header;
            this.VariableHeader = new MqttPublishAckVariableHeader(messageStream);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine(VariableHeader.ToString());

            return sb.ToString();
        }
    }
}
