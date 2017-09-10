toWhisper
=========

音声をささやき声にかえるソフトです．

zeta 様 (Twitter : https://twitter.com/zeta0313) 作成のC言語のソースコードをC#に移植しました。
- オリジナル https://github.com/zeta-chicken/toWhisper
- 解説動画 http://www.nicovideo.jp/watch/sm31882296

## ダウンロード

### 2017/9/11
- Windows用 [toWhisperNet v.1.1](https://github.com/ksasao/toWhisper/blob/master/ToWhisperNet1.1.zip?raw=true)
- オリジナルのコードの変更に合わせてアルゴリズムを修正
- 無音時の処理を改良

### 2017/9/10
- Windows用 [toWhisperNet v.1.0](https://github.com/ksasao/toWhisper/blob/master/ToWhisperNet1.0.zip?raw=true)
- 無音部がある音声ファイルがうまく変換できない場合に暫定対応しました
- 一部の機能が無効化されています

## 詳細
-------
LPCボコーダをによって推測した声道フィルタを使い，
ホワイトノイズを加工することによってささやき声を合成しています．

## 使い方
--------
```console
toWhisperNet [options] [infile]
options: -oのみ必須
    -o : 出力ファイル名 [N/A] [wavefile]
    -e : 声帯音源の出力ファイル名 [N/A] [wavefile]
    -l : lpfの強度 [0.97] (0.0 - 1.0)
    -r : 声帯音源の割合 [0.0] (0.0 - 1.0)
    -f : フレーム幅（ミリ秒） [20.0]
    -O : LPC次数 [auto]
    -p : 合成に関する情報を表示する．
    -h : helpメッセージの表示
infile:
    入力ファイル名（16bitモノラルのwavefileのみ）

example:
    toWhisper -o out.wav -l 0.6 in.wav
```

## コンパイル
-------------
Visual Studio 2017 で .sln ファイルを開いてビルドしてください。
- 無償の[Visual Studio Community](https://www.visualstudio.com/ja/downloads/?rr=https%3A%2F%2Fwww.microsoft.com%2Fja-jp%2Fdev%2Fproducts%2Fcommunity.aspx)でもビルドできます。

## ライセンス
-------------
オリジナルのライセンスと同じ修正BSDライセンスです。
