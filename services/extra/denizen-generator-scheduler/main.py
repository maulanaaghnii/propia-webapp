import time
import os
import subprocess

# Daftar file batch yang akan dijalankan
batch_files = [
    "request_1970_1980.bat",
    "request_1980_1990.bat",
    "request_1990_2000.bat"
]

def run_service():
    index = 0
    while True:
        # Jalankan file batch berdasarkan urutan
        batch_file = batch_files[index]
        if os.path.exists(batch_file):
            print(f"Menjalankan: {batch_file}")
            subprocess.run(batch_file, shell=True, capture_output=True)

        # Tunggu 15 detik sebelum menjalankan yang berikutnya
        # time.sleep(15)
        time.sleep(3)
        # Periksa apakah ada file baru yang ditambahkan
        existing_files = set(batch_files)
        all_files = {f for f in os.listdir() if f.endswith(".bat")}
        new_files = all_files - existing_files

        if new_files:
            print("File baru terdeteksi:", new_files)
            batch_files.extend(new_files)

        # Pindah ke file batch berikutnya dalam daftar (siklus berulang)
        index = (index + 1) % len(batch_files)

if __name__ == "__main__":
    run_service()
