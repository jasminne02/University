rule Detect_Malware {
    strings:
        $scam_word = "pay"
        $scam_note = "Your files are encrypted. To decrypt them, please send bitcoin to the following address"
        $malicious = "malicious"

    condition:
        $scam_word or $scam_note or $malicious
}
