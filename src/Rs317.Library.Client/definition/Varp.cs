using System;

namespace Rs317.Sharp
{

	public sealed class Varp
	{
		public static Varp[] values;
		public int type;

		public static void load(Archive archive)
		{
			Default317Buffer stream = new Default317Buffer(archive.decompressFile("varp.dat"));
			int count = stream.getUnsignedLEShort();

			if(values == null)
			{
				values = new Varp[count];
			}

			for(int i = 0; i < count; i++)
			{
				if(values[i] == null)
				{
					values[i] = new Varp();
				}

				values[i].load(stream);
			}

			if(stream.position != stream.buffer.Length)
			{
				throw new InvalidOperationException("varptype load mismatch");
			}
		}

		private void load(Default317Buffer buffer)
		{
			do
			{
				int opcode = buffer.getUnsignedByte();
				if(opcode == 0)
					return;
				if(opcode == 1)
					buffer.getUnsignedByte();
				else if(opcode == 2)
					buffer.getUnsignedByte();
				else if(opcode == 3)
				{
				} // dummy
				else if(opcode == 4)
				{
				} // dummy
				else if(opcode == 5)
					type = buffer.getUnsignedLEShort();
				else if(opcode == 6)
				{
				} // dummy
				else if(opcode == 7)
					buffer.getInt();
				else if(opcode == 8)
				{
				} // dummy
				else if(opcode == 10)
					buffer.getString();
				else if(opcode == 11)
				{
				} // dummy
				else if(opcode == 12)
					buffer.getInt();
				else if(opcode == 13)
				{
				} // dummy
				else
					throw new InvalidOperationException($"Error unrecognized config code: {opcode}");
			} while(true);
		}
	}
}
