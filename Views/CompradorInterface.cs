using System;
using System.Collections.Generic;

namespace Magic {
	class CompradorView {
		public enum MenuOptions { NULL, VER_ESTOQUE=1, COMPRAR=2, VER_COMPRADAS=3, SAIR=4 }

		public void ShowHeader(string title) {
			Console.Clear();
			Console.WriteLine("=== " + title + " ===\n");
		}

		public MenuOptions MainMenu() {
			ShowHeader("Comprador");

			Console.WriteLine("1 - Ver todas as cartas disponíveis");
			Console.WriteLine("2 - Comprar uma carta");
			Console.WriteLine("3 - Ver cartas compradas");
			Console.WriteLine("4 - Voltar\n");
			Console.Write("> ");

			try {
				var v = Convert.ToInt32(Console.ReadLine());
				if(v < 1 || v > 4) {
					Console.WriteLine("Opção inválida!");
					return MenuOptions.NULL;
				}
				return (MenuOptions)v;
			} catch {
				Console.WriteLine("Entrada inválida!");
				return MenuOptions.NULL;
			}
		}

		public void Pause() {
			Console.WriteLine("\nPressione Enter para continuar...");
			Console.ReadLine();
		}

		public int AskForSelection(int maxIndex) {
			Console.Write($"Escolha o número da carta (1-{maxIndex}) ou 0 para cancelar: ");
			try {
				int v = Convert.ToInt32(Console.ReadLine());
				if(v < 0 || v > maxIndex) return -1;
				return v;
			} catch {
				return -1;
			}
		}
	}
}

