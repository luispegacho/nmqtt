﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Nmqtt
{
    /// <summary>
    /// Implementation of the variable header for an MQTT Unsubscribe message.
    /// </summary>
    public sealed class MqttUnsubscribeVariableHeader : MqttVariableHeader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MqttUnsubscribeVariableHeader"/> class.
        /// </summary>
        public MqttUnsubscribeVariableHeader()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttUnsubscribeVariableHeader"/> class.
        /// </summary>
        /// <param name="headerStream">A stream containing the header of the message.</param>
        public MqttUnsubscribeVariableHeader(Stream headerStream)
            : base(headerStream)
        {
        }

        /// <summary>
        /// Returns the read flags for the Unsubscribe variabe header (prot name, version, Unsubscribe, keepalive)
        /// </summary>
        protected override MqttVariableHeader.ReadWriteFlags ReadFlags
        {
            get
            {
                return ReadWriteFlags.MessageIdentifier;
            }
        }

        /// <summary>
        /// Returns the write flags for the Unsubscribe variabe header (prot name, version, Unsubscribe, keepalive)
        /// </summary>
        protected override MqttVariableHeader.ReadWriteFlags WriteFlags
        {
            get
            {
                // we read and write the same values on the Unsubscribe header.
                return ReadFlags;
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return
                String.Format("Unsubscribe Variable Header: Message Identifier={0}", MessageIdentifier);
        }
    }
}
