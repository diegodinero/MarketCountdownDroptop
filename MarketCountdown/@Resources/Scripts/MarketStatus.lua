-- Market Status Script
-- Determines if a market is OPEN or CLOSED

function GetStatus(marketName, timeZoneId, open1, close1, open2, close2)
    -- Get current time in market timezone
    local os = require('os')
    local marketTime = os.date('%H:%M', os.time())
    
    -- Parse times (HH:MM format)
    local function parseTime(timeStr)
        local h, m = timeStr:match('(%d+):(%d+)')
        return tonumber(h) * 60 + tonumber(m)
    end
    
    local now = parseTime(marketTime)
    local o1 = parseTime(open1)
    local c1 = parseTime(close1)
    
    -- Check if market is open in session 1
    if now >= o1 and now < c1 then
        return 'OPEN'
    end
    
    -- Check if market is open in session 2 (if applicable)
    if open2 and close2 then
        local o2 = parseTime(open2)
        local c2 = parseTime(close2)
        if now >= o2 and now < c2 then
            return 'OPEN'
        end
    end
    
    return 'CLOSED'
end

function Update()
    local marketName = SELF:GetOption('MarketName', 'London')
    local timeZoneId = SELF:GetOption('MarketTimeZone', 'GMT Standard Time')
    local open1 = SELF:GetOption('MarketOpen1', '08:00')
    local close1 = SELF:GetOption('MarketClose1', '17:00')
    local open2 = SELF:GetOption('MarketOpen2', nil)
    local close2 = SELF:GetOption('MarketClose2', nil)
    
    return GetStatus(marketName, timeZoneId, open1, close1, open2, close2)
end
